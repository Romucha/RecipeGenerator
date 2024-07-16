using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.Implementations.Recipes.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.Recipes
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

        private TimeSpan recipeEstimatedTime;
        public TimeSpan RecipeEstimatedTime
        {
            get => recipeEstimatedTime; 
            set => SetProperty(ref recipeEstimatedTime, value);
        }

        private string recipeImage = default!;
        public string RecipeImage
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

        public async Task<Guid?> CreateAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Creating recipe...");
                CreateRecipeRequest createRecipeRequest = new();
                CreateRecipeResponse? createRecipeResponse = await unitOfWork.CreateAsync<Recipe, CreateRecipeRequest, CreateRecipeResponse>(createRecipeRequest, cancellationToken);
                logger.LogInformation("Editing recipe...");
                UpdateRecipeRequest updateRecipeRequest = new()
                {
                    Id = createRecipeResponse!.Id,
                    Name = RecipeName,
                    Description = RecipeDescription,
                    CourseType = (int?)RecipeCourseType,
                    EstimatedTime = RecipeEstimatedTime,
                    Image = RecipeImage,
                    Portions = RecipePortions,
                    Steps = new(),
                    Ingredients = new()
                };
                UpdateRecipeResponse? updateRecipeResponse = await unitOfWork.UpdateAsync<Recipe, UpdateRecipeRequest, UpdateRecipeResponse>(updateRecipeRequest, cancellationToken);
                if (updateRecipeResponse != null)
                {
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

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                logger.LogInformation("Saving changes...");
                await unitOfWork.SaveChangesAsync(cancellationToken);
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
    }
}
