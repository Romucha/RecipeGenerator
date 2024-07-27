using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.Implementations.ApplicableIngredients.Responses;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
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

        public async Task<Guid?> CreateAsync()
        {
            try
            {
                logger.LogInformation("Creating recipe...");
                CreateRecipeRequest createRecipeRequest = new();
                CreateRecipeResponse? createRecipeResponse = await unitOfWork.CreateAsync<Recipe, CreateRecipeRequest, CreateRecipeResponse>(createRecipeRequest);
                await SaveAsync();
                logger.LogInformation("Editing recipe...");
                Steps.ToList().ForEach(c => c.RecipeId = createRecipeResponse!.Id);
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
                    return updateRecipeResponse.Id;
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                return null;
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
                //TO-DO: the process breaks because of recipeID constraint. Make it nullable?
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
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }

        public async Task DeleteStepAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Deleting step...");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(AddStepAsync));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
