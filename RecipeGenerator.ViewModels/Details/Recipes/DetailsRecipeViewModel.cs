using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.DTO.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Recipes.Requests;
using RecipeGenerator.DTO.Recipes.Responses;
using RecipeGenerator.DTO.Steps.Responses;
using RecipeGenerator.Functionalities.Writers;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.ViewModels.Services;
using System.Collections.ObjectModel;
using System.Text;

namespace RecipeGenerator.ViewModels.Details.Recipes
{
    public class DetailsRecipeViewModel : ObservableObject
    {
        private readonly ILogger<DetailsRecipeViewModel> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileSaverService fileSaverService;
        private readonly IRecipeWriter recipeWriter;

        public DetailsRecipeViewModel(ILogger<DetailsRecipeViewModel> logger, IUnitOfWork unitOfWork, IFileSaverService fileSaverService, IRecipeWriter recipeWriter)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.fileSaverService = fileSaverService;
            this.recipeWriter = recipeWriter;
        }

        private Guid id;
        public Guid Id
        {
            get => id;
            set => this.SetProperty(ref id, value);
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
                GetRecipeResponse? response = await unitOfWork.RecipeRepository.GetAsync(recipeId);
                if (response != null)
                {
                    Id = recipeId;
                    Name = response.Name;
                    Description = response.Description;
                    Image = Convert.ToBase64String(response.Image);
                    CreatedAt = response.CreatedAt;
                    UpdatedAt = response.UpdatedAt;
                    CourseType = (Course)response.CourseType;
                    EstimatedTime = response.EstimatedTime;
                    Portions = response.Portions;

                    var ingredients = await unitOfWork.AppliedIngredientRepository.GetAllAsync(recipeId);
                    foreach (var ingredient in ingredients.Items)
                    {
                        var appliedIngredient = await unitOfWork.AppliedIngredientRepository.GetAsync(ingredient.Id);
                        if (appliedIngredient != null)
                            Ingredients.Add(appliedIngredient);
                    }

                    var steps = await unitOfWork.StepRepository.GetAllAsync(recipeId);
                    foreach (var step in steps.Items)
                    {
                        var s = await unitOfWork.StepRepository.GetAsync(step.Id);
                        if (s != null)
                            Steps.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(GetRecipeAsync));
            }
        }

        public async Task SaveRecipeAsync()
        {
            try
            {
                GetRecipeResponse? recipe = await unitOfWork.RecipeRepository.GetAsync(Id);
                if (recipe != null)
                {
                    var ingredientItems = (await unitOfWork.AppliedIngredientRepository.GetAllAsync(recipe.Id)).Items;
                    var stepItems = (await unitOfWork.StepRepository.GetAllAsync(recipe.Id)).Items;

                    var ingredients = GetAppliedIngredientsAsync(ingredientItems).ToBlockingEnumerable();
                    var steps = GetStepsAsync(stepItems).ToBlockingEnumerable();
                    
                    recipeWriter.Write(recipe, ingredients, steps);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SaveRecipeAsync));
            }
        }

        private async IAsyncEnumerable<GetAppliedIngredientResponse?> GetAppliedIngredientsAsync(IEnumerable<GetAllAppliedIngredientsResponseItem> items)
        {
            foreach (var item in items)
            {
                yield return await unitOfWork.AppliedIngredientRepository.GetAsync(item.Id);
            }
        }

        private async IAsyncEnumerable<GetStepResponse?> GetStepsAsync(IEnumerable<GetAllStepsResponseItem> items)
        {
            foreach (var item in items)
            {
                yield return await unitOfWork.StepRepository.GetAsync(item.Id);
            }
        }
    }
}
