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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.Create.Ingredients
{
    public class CreateRecipeViewModel : ObservableObject
    {
        private readonly ILogger<CreateRecipeViewModel> logger;
        private readonly IUnitOfWork unitOfWork;

        public CreateRecipeViewModel(ILogger<CreateRecipeViewModel> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
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

        public async Task GetApplicableIngredientsAsync()
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
                CreateRecipeRequest createRecipeRequest = new();
                CreateRecipeResponse? createRecipeResponse = await unitOfWork.CreateAsync<Recipe, CreateRecipeRequest, CreateRecipeResponse>(createRecipeRequest);
                await SaveAsync();
                logger.LogInformation("Editing recipe...");
                Steps.ToList().ForEach(c => c.RecipeId = createRecipeResponse!.Id);
                AppliedIngredients.ToList().ForEach(c => c.RecipeId = createRecipeResponse!.Id);
                UpdateRecipeRequest updateRecipeRequest = new()
                {
                    Id = createRecipeResponse!.Id,
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
    }
}
