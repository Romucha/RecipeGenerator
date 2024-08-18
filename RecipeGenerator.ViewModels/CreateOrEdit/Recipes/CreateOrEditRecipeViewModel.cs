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

        private ObservableCollection<GetStepResponse> steps = new();
        public ObservableCollection<GetStepResponse> Steps
        {
            get => steps;
            set => SetProperty(ref steps, value);
        }

        private int stepIndex = 0;
        public int StepIndex
        {
            get => stepIndex;
            set => SetProperty(ref stepIndex, value);
        }

        private ObservableCollection<GetAppliedIngredientResponse> appliedIngredients = new();
        public ObservableCollection<GetAppliedIngredientResponse> AppliedIngredients
        {
            get => appliedIngredients;
            set => SetProperty(ref appliedIngredients, value);
        }

        private ObservableCollection<GetAllApplicableIngredientsResponseItem> applicableIngredients = new();
        public ObservableCollection<GetAllApplicableIngredientsResponseItem> ApplicableIngredients
        {
            get => applicableIngredients;
            set => SetProperty(ref applicableIngredients, value);
        }

        public Guid SelectedIngredientId { get; set; } = default!;

        public async Task InitializeAsync(Guid? id)
        {
            try
            {
                logger.LogInformation($"Initializing view model with recipe {id}...");
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
                        List<GetStepResponse> steps = new();
                        foreach (var s in (await unitOfWork.StepRepository.GetAllAsync(RecipeId)).Items)
                        {
                            steps.Add(await unitOfWork.StepRepository.GetAsync(s.Id));
                        }
                        Steps = new ObservableCollection<GetStepResponse>(steps);

                        List<GetAppliedIngredientResponse> appliedIngredients = new();
                        foreach (var ai in (await unitOfWork.AppliedIngredientRepository.GetAllAsync(RecipeId)).Items)
                        {
                            appliedIngredients.Add(await unitOfWork.AppliedIngredientRepository.GetAsync(ai.Id));
                        }
                        AppliedIngredients = new ObservableCollection<GetAppliedIngredientResponse>(appliedIngredients);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(InitializeAsync));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        private async Task GetApplicableIngredientsAsync()
        {
            try
            {
                logger.LogInformation("Initializing view model...");
                GetAllApplicableIngredientsRequest getAllApplicableIngredientsRequest = new GetAllApplicableIngredientsRequest();

                GetAllApplicableIngredientsResponse? getAllApplicableIngredientsResponse = await unitOfWork.ApplicableIngredientRepository.GetAllAsync(0, 0, "");
                if (getAllApplicableIngredientsResponse != null)
                {
                    ApplicableIngredients = new(getAllApplicableIngredientsResponse
                        .Items
                        .Where(c => !AppliedIngredients.Any(x => x.IngredientId == c.Id))
                        .OrderBy(c => c.Name));
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetApplicableIngredientsAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task AddAppliedIngredientAsync()
        {
            try
            {
                logger.LogInformation("Adding an applied ingredient...");
                if (SelectedIngredientId != default)
                {

                    CreateAppliedIndredientResponse createAppliedIndredientResponse 
                        = await unitOfWork.AppliedIngredientRepository.CreateAsync(RecipeId, SelectedIngredientId);
                    
                    GetApplicableIngredientResponse getApplicableIngredientResponse 
                        = await unitOfWork.ApplicableIngredientRepository.GetAsync(SelectedIngredientId);
                    if (getApplicableIngredientResponse != null)
                    {
                        GetAppliedIngredientResponse getAppliedIngredientResponse = new()
                        {
                            IngredientId = getApplicableIngredientResponse.Id,
                            Name = getApplicableIngredientResponse.Name,
                            Description = getApplicableIngredientResponse.Description,
                        };
                        AppliedIngredients.Add(getAppliedIngredientResponse);
                        await GetApplicableIngredientsAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(AddAppliedIngredientAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task CreateAsync()
        {
            try
            {
                GetRecipeResponse? getRecipeResponse = await unitOfWork.RecipeRepository.GetAsync(RecipeId);
                if (getRecipeResponse == null)
                {
                    CreateRecipeResponse? createRecipeResponse = await unitOfWork.RecipeRepository.CreateAsync();
                    if (createRecipeResponse != null)
                    {
                        RecipeId = createRecipeResponse.Id;
                    }
                }
                logger.LogInformation("Editing recipe...");
                Steps.ToList().ForEach(c => c.RecipeId = RecipeId);
                AppliedIngredients.ToList().ForEach(c => c.RecipeId = RecipeId);
                await unitOfWork.RecipeRepository.UpdateAsync(RecipeId, Name, Description, Image, CourseType, TimeSpan.FromMinutes(EstimatedTime), Portions);

                foreach (var appliedIngredient in AppliedIngredients)
                {
                    await unitOfWork.AppliedIngredientRepository.UpdateAsync(appliedIngredient.Id, appliedIngredient.Name, appliedIngredient.Description);
                }

                foreach (var step in Steps)
                {
                    await unitOfWork.StepRepository.UpdateAsync(step.Id, step.Name, step.Description, step.Photos, step.Index);
                }
                
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                logger.LogInformation("Saving changes...");
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SaveAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task AddStepAsync()
        {
            try
            {
                CreateStepResponse? createStepResponse = await unitOfWork.StepRepository.CreateAsync(RecipeId);
                if (createStepResponse != null)
                {
                    GetStepResponse getStepResponse = new()
                    {
                        Id = createStepResponse.Id,
                        Index = StepIndex++
                    };
                    Steps.Add(getStepResponse);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(AddStepAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task DeleteStepAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation($"Deleting step {id}...");
                var step = Steps.FirstOrDefault(s => s.Id == id);
                if (step != null)
                {
                    DeleteStepRequest deleteStepRequest = new()
                    {
                        Id = step.Id,
                    };

                    DeleteStepResponse? deleteStepResponse = await unitOfWork.StepRepository.DeleteAsync(step.Id);
                    if (deleteStepResponse != null)
                    {
                        await SaveAsync();
                        Steps.Where(c => c.Index > step.Index).ToList().ForEach(s => --s.Index);
                        --StepIndex;
                        Steps.Remove(step);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(AddStepAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task DeleteAppliedIngredientAsync(Guid id)
        {
            try
            {
                logger.LogInformation($"Deleting applied ingredient {id}...");
                var appliedIngredient = AppliedIngredients.FirstOrDefault(s => s.Id == id);
                if (appliedIngredient != null)
                {
                    DeleteAppliedIngredientRequest deleteAppliedIngredientRequest = new()
                    {
                        Id = id
                    };
                    DeleteAppliedIngredientResponse? deleteAppliedIngredientResponse = await unitOfWork.AppliedIngredientRepository.DeleteAsync(id);
                    if (deleteAppliedIngredientResponse != null)
                    {
                        await SaveAsync();
                        AppliedIngredients.Remove(appliedIngredient);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(DeleteAppliedIngredientAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task TakeRecipePhotoAsync()
        {
            try
            {
                logger.LogInformation("Taking a photo for the recipe...");
                Image = await mediaProviderService.TakePhotoAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(TakeRecipePhotoAsync));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task SelectRecipePhotoAsync()
        {
            try
            {
                logger.LogInformation("Selecting a photo for the recipe from file system...");
                Image = await mediaProviderService.SelectPhotoAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SelectRecipePhotoAsync));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task TakeStepPhotoAsync(Guid stepId)
        {
            try
            {
                logger.LogInformation($"Taking a photo for the step {stepId}...");
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
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task SelectStepPhotoAsync(Guid stepId)
        {
            try
            {
                logger.LogInformation($"Selecting a photo for the step {stepId} from file system...");
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
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
