using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.ViewModels.Start
{
    public class StartVM : ObservableObject
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IIngredientRepository ingredientRepository;
        private readonly IRecipeFactory recipeFactory;
        private readonly IStepFactory stepFactory;

        private Recipe recipe;

        public Recipe Recipe
        {
            get => recipe;
            set => SetProperty(ref recipe, value);
        }

        private IEnumerable<CourseListItem> courseList;

        public IEnumerable<CourseListItem> CourseList
        {
            get => courseList;
            set => SetProperty(ref courseList, value);
        }

        private IEnumerable<Ingredient> ingredientList;

        public IEnumerable<Ingredient> IngredientList
        {
            get => ingredientList;
            set => SetProperty(ref ingredientList, value);
        }

        public StartVM(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IRecipeFactory recipeFactory, IStepFactory stepFactory)
        {
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeFactory = recipeFactory;
            this.stepFactory = stepFactory;
            SetCourseListCommand = new RelayCommand(setCourseList);

            ResetRecipeCommand = new AsyncRelayCommand(resetRecipe);
            AddRecipeCommand = new AsyncRelayCommand(addRecipe);

            AddStepCommand = new RelayCommand(addStep);
            DeleteStepCommand = new RelayCommand<Step>(deleteStep);

            GetIngredientListCommand = new AsyncRelayCommand(getIngedientList);
            AddIngredientCommand = new RelayCommand<Ingredient>(addIngredient);
            DeleteIngredientCommand = new RelayCommand<Ingredient>(deleteIngredient);
        }
        #region Preparations
        private void setCourseList()
        {
            CourseList = Enum.GetValues<Course>().Select(CourseListItem.FromCourse);
        }
        /// <summary>
        /// Sets up list of possible courses for the recipe
        /// </summary>
        public IRelayCommand SetCourseListCommand { get; private set; }
        #endregion

        #region Recipes
        private async Task resetRecipe()
        {
            Recipe = await recipeFactory.DefaultRecipe();
        }
        /// <summary>
        /// Resets recipe to a default state
        /// </summary>
        public IAsyncRelayCommand ResetRecipeCommand { get; private set; }

        private async Task addRecipe()
        {
            await recipeRepository.Add(recipe);
        }
        /// <summary>
        /// Adds recipe to database
        /// </summary>
        public IAsyncRelayCommand AddRecipeCommand { get; private set; }
        #endregion

        #region Steps
        private void addStep()
        {
            Recipe.Steps?.Add(stepFactory.DefaultStep());
        }
        /// <summary>
        /// Adds a new step to recipe
        /// </summary>
        public IRelayCommand AddStepCommand { get; private set; }

        private void deleteStep(Step step)
        {
            Recipe.Steps?.Remove(step);
        }
        public IRelayCommand<Step> DeleteStepCommand { get; private set; }
        #endregion

        #region Ingredients
        private async Task getIngedientList()
        {
            IngredientList = await ingredientRepository.GetAll();
        }
        public IAsyncRelayCommand GetIngredientListCommand { get; private set; }

        private void addIngredient(Ingredient ingredient)
        {
            Recipe.Ingredients?.Add(ingredient);
        }
        /// <summary>
        /// Adds a new ingredient to recipe
        /// </summary>
        public IRelayCommand<Ingredient> AddIngredientCommand { get; private set; }

        private void deleteIngredient(Ingredient ingredient)
        {
            Recipe.Ingredients?.Remove(ingredient);
        }
        /// <summary>
        /// Deletes ingredient from recipe
        /// </summary>
        public IRelayCommand<Ingredient> DeleteIngredientCommand { get; private set; }
        #endregion
    }
}
