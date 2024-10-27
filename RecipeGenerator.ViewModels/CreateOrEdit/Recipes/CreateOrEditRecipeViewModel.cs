using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.ApplicableIngredients.Responses;
using RecipeGenerator.DTO.AppliedIngredients.Requests;
using RecipeGenerator.DTO.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Recipes.Requests;
using RecipeGenerator.DTO.Recipes.Responses;
using RecipeGenerator.DTO.Steps.Requests;
using RecipeGenerator.DTO.Steps.Responses;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using RecipeGenerator.ViewModels.Services;
using System.Collections.ObjectModel;

namespace RecipeGenerator.ViewModels.CreateOrEdit.Recipes
{
    public class CreateOrEditRecipeViewModel : ObservableObject
    {
        private readonly ILogger<CreateOrEditRecipeViewModel> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediaProviderService mediaProviderService;

        private Guid RecipeId;

        public CreateOrEditRecipeViewModel(ILogger<CreateOrEditRecipeViewModel> logger, IUnitOfWork unitOfWork, IMediaProviderService mediaProviderService)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.mediaProviderService = mediaProviderService;
        }

        private string name = default!;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string description = default!;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private Course courseType;
        public Course CourseType
        {
            get => courseType;
            set => SetProperty(ref courseType, value);
        }

        private double estimatedTime;
        public double EstimatedTime
        {
            get => estimatedTime;
            set => SetProperty(ref estimatedTime, value);
        }

        private byte[] image = default!;
        public byte[] Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        private int portions;
        public int Portions
        {
            get => portions;
            set => SetProperty(ref portions, value);
        }

        private ObservableCollection<UpdateStepRequest> steps = new();
        public ObservableCollection<UpdateStepRequest> Steps
        {
            get => steps;
            set => SetProperty(ref steps, value);
        }

        private List<DeleteStepRequest> stepsToDelete = new();

        private int stepIndex = 0;
        public int StepIndex
        {
            get => stepIndex;
            set => SetProperty(ref stepIndex, value);
        }

        private ObservableCollection<UpdateAppliedIngredientRequest> appliedIngredients = new();
        public ObservableCollection<UpdateAppliedIngredientRequest> AppliedIngredients
        {
            get => appliedIngredients;
            set => SetProperty(ref appliedIngredients, value);
        }

        private List<DeleteAppliedIngredientRequest> appliedIngredientsToDelete = new();

        private ObservableCollection<GetAllApplicableIngredientsResponseItem> applicableIngredients = new();
        public ObservableCollection<GetAllApplicableIngredientsResponseItem> ApplicableIngredients
        {
            get => applicableIngredients;
            set => SetProperty(ref applicableIngredients, value);
        }

        public Guid SelectedIngredientId { get; set; } = default!;

        /*
         * General idea:
         * 1. Initialize view model. If it receives recipe, it gets it from database and fills view model with data from it.
         * 2. Otherwise it creates a new recipe in database.
         * 3. User fills regular parameters of recipe (name, description, etc.).
         * 4. User fills lists of other entities (steps and applicable ingredients).
         * 5. User presses button save.
         * 6. Request to update recipe gets sent to database.
         * 7. For each step and ingredient we check if it exists. If it does, we update its values. Otherwise we create it (CREATE OR UPDATE).
         * 8. Changes are saved.
         */

        public async Task InitializeAsync(Guid? id)
        {
            try
            {
                await GetApplicableIngredientsAsync();
                if (id != null)
                {
                    RecipeId = (Guid)id;

                    GetRecipeResponse? getRecipeResponse = await unitOfWork.RecipeRepository.GetAsync(RecipeId);
                    if (getRecipeResponse != null)
                    {
                        Name = getRecipeResponse.Name;
                        Description = getRecipeResponse.Description;
                        CourseType = (Course)getRecipeResponse.CourseType;
                        Image = getRecipeResponse.Image;
                        Portions = getRecipeResponse.Portions;
                        EstimatedTime = getRecipeResponse.EstimatedTime.TotalMinutes;
                        List<UpdateStepRequest> steps = new();
                        foreach (var s in (await unitOfWork.StepRepository.GetAllAsync(RecipeId)).Items)
                        {
                            var step = await unitOfWork.StepRepository.GetAsync(s.Id);
                            if (step != null)
                            {
                                steps.Add(new()
                                {
                                    Id = step.Id,
                                    Name = step.Name,
                                    Description = step.Description,
                                    Index = step.Index,
                                    Photos = step.Photos,
                                    RecipeId = step.RecipeId,
                                });
                            }
                        }
                        Steps = new(steps);

                        List<UpdateAppliedIngredientRequest> appliedIngredients = new();
                        foreach (var ai in (await unitOfWork.AppliedIngredientRepository.GetAllAsync(RecipeId)).Items)
                        {
                            var ingredient = await unitOfWork.AppliedIngredientRepository.GetAsync(ai.Id);
                            if (ingredient != null)
                            {
                                appliedIngredients.Add(new()
                                {
                                    Id = ingredient.Id,
                                    Name = ingredient.Name,
                                    Description = ingredient.Description,
                                    IngredientId = ingredient.IngredientId,
                                    RecipeId = ingredient.RecipeId
                                });
                            }
                        }
                        AppliedIngredients = new(appliedIngredients);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(InitializeAsync));
            }
        }

        private async Task GetApplicableIngredientsAsync()
        {
            try
            {
                GetAllApplicableIngredientsRequest getAllApplicableIngredientsRequest = new GetAllApplicableIngredientsRequest();

                GetAllApplicableIngredientsResponse? getAllApplicableIngredientsResponse = await unitOfWork.ApplicableIngredientRepository.GetAllAsync(0, 0, "");
                if (getAllApplicableIngredientsResponse != null)
                {
                    ApplicableIngredients = new(getAllApplicableIngredientsResponse
                        .Items
                        .Where(c => !AppliedIngredients.Any(x => x.IngredientId == c.Id && x.RecipeId == RecipeId))
                        .OrderBy(c => c.Name));
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetApplicableIngredientsAsync));
                throw;
            }
        }

        public async Task AddAppliedIngredientAsync()
        {
            try
            {
                if (SelectedIngredientId != default)
                {
                    var response = await unitOfWork.ApplicableIngredientRepository.GetAsync(SelectedIngredientId);
                    if (response != null)
                    {
                        UpdateAppliedIngredientRequest request = new()
                        {
                            //if the primary id is default, we create the entity
                            Name = response.Name,
                            Description = response.Description,
                            IngredientId = SelectedIngredientId,
                            RecipeId = RecipeId
                        };
                        AppliedIngredients.Add(request);
                        await GetApplicableIngredientsAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(AddAppliedIngredientAsync));
                throw;
            }
        }

        public async Task CreateAsync()
        {
            try
            {   
                if (RecipeId == default)
                {
                    CreateRecipeResponse? createRecipeResponse = await unitOfWork.RecipeRepository.CreateAsync();
                    if (createRecipeResponse != null)
                    {
                        RecipeId = createRecipeResponse.Id;
                        await unitOfWork.SaveChangesAsync();
                        foreach (var ingredient in this.AppliedIngredients)
                        {
                            ingredient.RecipeId = RecipeId;
                        }
                        foreach (var step in this.Steps)
                        {
                            step.RecipeId = RecipeId;
                        }
                    }
                }

                await unitOfWork.RecipeRepository.UpdateAsync(RecipeId, Name, Description, Image, CourseType, TimeSpan.FromMinutes(EstimatedTime), Portions);

                foreach (var appliedIngredient in AppliedIngredients)
                {
                    await unitOfWork.AppliedIngredientRepository.UpdateAsync(appliedIngredient.Id, appliedIngredient.Name, appliedIngredient.Description, appliedIngredient.RecipeId, appliedIngredient.IngredientId);
                }

                foreach (var appliedIngredientToDelete in appliedIngredientsToDelete)
                {
                    await unitOfWork.AppliedIngredientRepository.DeleteAsync(appliedIngredientToDelete.Id);
                }

                foreach (var step in Steps)
                {
                    await unitOfWork.StepRepository.UpdateAsync(step.Id, step.Name, step.Description, step.Photos, step.Index, step.RecipeId);
                }

                foreach (var stepToDelete in stepsToDelete)
                {
                    await unitOfWork.StepRepository.DeleteAsync(stepToDelete.Id);
                }
                
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                throw;
            }
        }

        public async Task AddStepAsync()
        {
            try
            {
                UpdateStepRequest request = await Task.FromResult(new UpdateStepRequest
                {
                    Index = StepIndex++,
                    RecipeId = RecipeId,
                });
                Steps.Add(request);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(AddStepAsync));
                throw;
            }
        }

        public async Task DeleteStepAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var step = await Task.FromResult(Steps.FirstOrDefault(s => s.Id == id));
                if (step != null)
                {
                    DeleteStepRequest deleteStepRequest = new()
                    {
                        Id = step.Id,
                    };
                    stepsToDelete.Add(deleteStepRequest);
                    Steps.Where(c => c.Index > step.Index).ToList().ForEach(s => --s.Index);
                    --StepIndex;
                    Steps.Remove(step);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(AddStepAsync));
                throw;
            }
        }

        public async Task DeleteAppliedIngredientAsync(Guid id)
        {
            try
            { 
                var appliedIngredient = AppliedIngredients.FirstOrDefault(s => s.Id == id);
                if (appliedIngredient != null)
                {
                    var request = new DeleteAppliedIngredientRequest()
                    {
                        Id = appliedIngredient.Id,
                    };
                    appliedIngredientsToDelete.Add(request);
                    AppliedIngredients.Remove(appliedIngredient);
                    await GetApplicableIngredientsAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAppliedIngredientAsync));
                throw;
            }
        }

        public async Task TakeRecipePhotoAsync()
        {
            try
            {
                Image = await mediaProviderService.TakePhotoAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(TakeRecipePhotoAsync));
            }
        }

        public async Task SelectRecipePhotoAsync()
        {
            try
            {
                Image = await mediaProviderService.SelectPhotoAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SelectRecipePhotoAsync));
            }
        }

        public async Task TakeStepPhotoAsync(Guid stepId)
        {
            try
            {
                var step = Steps.FirstOrDefault(s => s.Id == stepId);
                if (step != null)
                {
                    if (step.Photos is null)
                        step.Photos = new();
                    step.Photos.Add(await mediaProviderService.TakePhotoAsync());
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(TakeRecipePhotoAsync));
                throw;
            }
        }

        public async Task SelectStepPhotoAsync(Guid stepId)
        {
            try
            {
                var step = Steps.FirstOrDefault(s => s.Id == stepId);
                if (step != null)
                {
                    if (step.Photos is null)
                        step.Photos = new();
                    step.Photos.Add(await mediaProviderService.SelectPhotoAsync());
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SelectRecipePhotoAsync));
            }
        }
    }
}
