using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Implementations.Recipes.Requests;
using RecipeGenerator.DTO.Implementations.Recipes.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.Details.Recipes
{
    public class DetailsRecipeViewModel : ObservableObject
    {
        private readonly ILogger<DetailsRecipeViewModel> logger;
        private readonly IUnitOfWork unitOfWork;

        public DetailsRecipeViewModel(ILogger<DetailsRecipeViewModel> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        private DateTime createdAt;
        public DateTime CreatedAt 
        {
            get => createdAt;
            set => SetProperty(ref createdAt, value);
        }

        private DateTime updatedAt;
        public DateTime UpdatedAt 
        { 
            get => updatedAt;
            set => SetProperty(ref updatedAt, value);
        }

        private string name = string.Empty;
        public string Name 
        { 
            get => name; 
            set => SetProperty(ref name, value);
        }

        private string description = string.Empty;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private string image = string.Empty;
        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        private Course courseType;
        public Course CourseType 
        { 
            get => courseType; 
            set => SetProperty(ref courseType, value);
        }

        private TimeSpan estimatedTime;
        public TimeSpan EstimatedTime 
        { 
            get => estimatedTime; 
            set => SetProperty(ref estimatedTime, value);
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
        private ObservableCollection<GetAppliedIngredientResponse> ingredients = new();
        public ObservableCollection<GetAppliedIngredientResponse> Ingredients 
        { 
            get => ingredients; 
            set => SetProperty(ref ingredients, value);
        }

        public async Task GetRecipeAsync(Guid recipeId)
        {
            try
            {
                logger.LogInformation("Getting recipe...");
                GetRecipeRequest getRecipeRequest = new GetRecipeRequest()
                {
                    Id = recipeId
                };
                GetRecipeResponse? response = await unitOfWork.GetAsync<Recipe, GetRecipeRequest, GetRecipeResponse>(getRecipeRequest);
                if (response != null)
                {
                    Name = response.Name;
                    Description = response.Description;
                    Image = response.Image;
                    CreatedAt = response.CreatedAt;
                    UpdatedAt = response.UpdatedAt;
                    CourseType = (Course)response.CourseType;
                    EstimatedTime = response.EstimatedTime;
                    Portions = response.Portions;
                    Steps = new(response.Steps);
                    Ingredients = new(response.Ingredients);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetRecipeAsync));
            }
            finally
            {
                logger.LogInformation("Done.");
            }
        }
    }
}
