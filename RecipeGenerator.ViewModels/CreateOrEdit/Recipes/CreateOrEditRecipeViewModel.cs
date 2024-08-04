using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Responses;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Implementations.Recipes.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using RecipeGenerator.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private string recipeName = default!;
        public string RecipeName
        {
            get => recipeName;
            set => SetProperty(ref recipeName, value);
        }

        private string recipeDescription = default!;
        public string RecipeDescription
        {
            get => recipeDescription;
            set => SetProperty(ref recipeDescription, value);
        }

        private Course recipeCourseType;
        public Course RecipeCourseType
        {
            get => recipeCourseType;
            set => SetProperty(ref recipeCourseType, value);
        }

        private double recipeEstimatedTime;
        public double RecipeEstimatedTime
        {
            get => recipeEstimatedTime;
            set => SetProperty(ref recipeEstimatedTime, value);
        }

        private byte[] recipeImage = default!;
        public byte[] RecipeImage
        {
            get => recipeImage;
            set => SetProperty(ref recipeImage, value);
        }

        private int recipePortions;
        public int RecipePortions
        {
            get => recipePortions;
            set => SetProperty(ref recipePortions, value);
        }

        private ObservableCollection<UpdateStepRequest> steps = new();
        public ObservableCollection<UpdateStepRequest> Steps
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

        private ObservableCollection<UpdateAppliedIngredientRequest> appliedIngredients = new();
        public ObservableCollection<UpdateAppliedIngredientRequest> AppliedIngredients
        {
            get => appliedIngredients;
            set => SetProperty(ref appliedIngredients, value);
        }

        private ObservableCollection<GetAllApplicableIngredientResponse> applicableIngredients = new();
        public ObservableCollection<GetAllApplicableIngredientResponse> ApplicableIngredients
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
                    GetRecipeRequest request = new GetRecipeRequest()
                    {
                        Id = RecipeId
                    };

                    GetRecipeResponse? getRecipeResponse = await unitOfWork.GetAsync<Recipe, GetRecipeRequest, GetRecipeResponse>(request);
                    if (getRecipeResponse != null)
                    {
                        RecipeName = getRecipeResponse.Name;
                        RecipeDescription = getRecipeResponse.Description;
                        RecipeCourseType = (Course)getRecipeResponse.CourseType;
                        RecipeImage = getRecipeResponse.Image;
                        RecipePortions = getRecipeResponse.Portions;
                        RecipeEstimatedTime = getRecipeResponse.EstimatedTime.TotalMinutes;
                        Steps = new ObservableCollection<UpdateStepRequest>(getRecipeResponse.Steps.Select(c => new UpdateStepRequest()
                        {
                            Id = c.Id,
                            Description = c.Description,
                            Photos = c.Photos,
                            Index = c.Index,
                            Name = c.Name,
                            RecipeId = RecipeId,
                        }));
                        AppliedIngredients = new ObservableCollection<UpdateAppliedIngredientRequest>(getRecipeResponse.Ingredients.Select(c => new UpdateAppliedIngredientRequest()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Description = c.Description,
                            IngredientId = c.IngredientId,
                            RecipeId = c.RecipeId,
                        }));
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

                GetAllApplicableIngredientsResponse? getAllApplicableIngredientsResponse = await unitOfWork.GetAllAsync<ApplicableIngredient, GetAllApplicableIngredientsRequest, GetAllApplicableIngredientsResponse, GetAllApplicableIngredientResponse>(getAllApplicableIngredientsRequest);
                if (getAllApplicableIngredientsResponse != null)
                {
                    ApplicableIngredients = new(getAllApplicableIngredientsResponse
                        .Items
                        .Select(c => (GetAllApplicableIngredientResponse)c)
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
                CreateAppliedIngredientRequest createAppliedIngredientRequest = new CreateAppliedIngredientRequest();
                CreateAppliedIndredientResponse? createAppliedIndredientResponse = await unitOfWork.CreateAsync<AppliedIngredient, CreateAppliedIngredientRequest, CreateAppliedIndredientResponse>(createAppliedIngredientRequest);
                if (createAppliedIndredientResponse != null)
                {
                    await SaveAsync();
                    if (SelectedIngredientId != default)
                    {
                        GetApplicableIngredientRequest getApplicableIngredientRequest = new()
                        {
                            Id = SelectedIngredientId
                        };
                        GetApplicableIngredientResponse? getApplicableIngredientResponse = await unitOfWork.GetAsync<ApplicableIngredient, GetApplicableIngredientRequest, GetApplicableIngredientResponse>(getApplicableIngredientRequest);
                        if (getApplicableIngredientResponse != null)
                        {
                            UpdateAppliedIngredientRequest updateAppliedIngredientRequest = new()
                            {
                                Id = createAppliedIndredientResponse.Id,
                                IngredientId = getApplicableIngredientResponse.Id,
                                Name = getApplicableIngredientResponse.Name,
                                Description = getApplicableIngredientResponse.Description,
                            };
                            AppliedIngredients.Add(updateAppliedIngredientRequest);
                            await GetApplicableIngredientsAsync();
                        }
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
                logger.LogInformation("Creating recipe...");
                GetRecipeRequest? getRecipeRequest = new()
                {
                    Id = RecipeId
                };
                GetRecipeResponse? getRecipeResponse = await unitOfWork.GetAsync<Recipe, GetRecipeRequest, GetRecipeResponse>(getRecipeRequest);
                if (getRecipeResponse == null)
                {

                    CreateRecipeRequest createRecipeRequest = new();
                    CreateRecipeResponse? createRecipeResponse = await unitOfWork.CreateAsync<Recipe, CreateRecipeRequest, CreateRecipeResponse>(createRecipeRequest);
                    if (createRecipeResponse != null)
                    {
                        RecipeId = createRecipeResponse.Id;
                    }
                    await SaveAsync();
                }
                logger.LogInformation("Editing recipe...");
                Steps.ToList().ForEach(c => c.RecipeId = RecipeId);
                AppliedIngredients.ToList().ForEach(c => c.RecipeId = RecipeId);
                UpdateRecipeRequest updateRecipeRequest = new()
                {
                    Id = RecipeId,
                    Name = RecipeName,
                    Description = RecipeDescription,
                    CourseType = (int?)RecipeCourseType,
                    EstimatedTime = TimeSpan.FromMinutes(RecipeEstimatedTime),
                    Image = RecipeImage,
                    Portions = RecipePortions,
                    Steps = [.. Steps],
                    Ingredients = [.. AppliedIngredients]
                };
                UpdateRecipeResponse? updateRecipeResponse = await unitOfWork.UpdateAsync<Recipe, UpdateRecipeRequest, UpdateRecipeResponse>(updateRecipeRequest);
                if (updateRecipeResponse != null)
                {
                    await SaveAsync();
                }
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
                CreateStepRequest createStepRequest = new();
                CreateStepResponse? createStepResponse = await unitOfWork.CreateAsync<Step, CreateStepRequest, CreateStepResponse>(createStepRequest);
                if (createStepResponse != null)
                {
                    await SaveAsync();
                    UpdateStepRequest updateStepRequest = new()
                    {
                        Id = createStepResponse.Id,
                        Index = StepIndex++
                    };
                    Steps.Add(updateStepRequest);
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

                    DeleteStepResponse? deleteStepResponse = await unitOfWork.DeleteAsync<Step, DeleteStepRequest, DeleteStepResponse>(deleteStepRequest);
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
                    DeleteAppliedIngredientResponse? deleteAppliedIngredientResponse = await unitOfWork.DeleteAsync<AppliedIngredient, DeleteAppliedIngredientRequest, DeleteAppliedIngredientResponse>(deleteAppliedIngredientRequest);
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
                RecipeImage = await mediaProviderService.TakePhotoAsync();
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
                RecipeImage = await mediaProviderService.SelectPhotoAsync();
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
