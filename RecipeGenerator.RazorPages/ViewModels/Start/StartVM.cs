﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// <summary>
        /// A recipe to be added
        /// </summary>
        public Recipe Recipe
        {
            get => recipe;
            set => SetProperty(ref recipe, value);
        }

        private IEnumerable<CourseListItem> courseList;
        /// <summary>
        /// List of possible course types of a new recipe
        /// </summary>
        public IEnumerable<CourseListItem> CourseList
        {
            get => courseList;
            set => SetProperty(ref courseList, value);
        }

        private IEnumerable<IngredientTypeListItem> ingredientTypeList;
        /// <summary>
        /// List of possible types of an ingredient
        /// </summary>
        public IEnumerable<IngredientTypeListItem> IngredientTypeList
        {
            get => ingredientTypeList;
            set => SetProperty(ref ingredientTypeList, value);
        }

        private IngredientType selectedIngredientType;
        /// <summary>
        /// Selected type of future ingredient
        /// </summary>
        public IngredientType SelectedIngredientType
        {
            get => selectedIngredientType;
            set
            { 
                SetProperty(ref selectedIngredientType, value);
                updateAllIngedientList(value); 
            }
        }

        private IEnumerable<string> allIngredientList;
        /// <summary>
        /// List of names of all avaliable ingredients
        /// </summary>
        public IEnumerable<string> AllIngredientList
        {
            get => allIngredientList;
            set => SetProperty(ref allIngredientList, value);
        }

        private ObservableCollection<Step> stepList;
        /// <summary>
        /// List of steps of a new recipe
        /// </summary>
        public ObservableCollection<Step> StepList
        {
            get => stepList;
            set => SetProperty(ref stepList, value);
        }

        private ObservableCollection<Ingredient> ingredientList;
        /// <summary>
        /// List of ingredients of a new recipe
        /// </summary>
        public ObservableCollection<Ingredient> IngredientList
        {
            get => ingredientList;
            set => SetProperty(ref ingredientList, value);
        }

        private string selectedIngredientName;
        /// <summary>
        /// Ingredient to add to list of ingredients
        /// </summary>
        public string SelectedIngredientName
        {
            get => selectedIngredientName;
            set => SetProperty(ref selectedIngredientName, value);
        }

        public StartVM(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IRecipeFactory recipeFactory, IStepFactory stepFactory)
        {
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeFactory = recipeFactory;
            this.stepFactory = stepFactory;

            GetCourseListCommand = new RelayCommand(getCourseList);
            GetIngredientTypesListCommand = new RelayCommand(getIngredientTypesList);

            ResetRecipeCommand = new AsyncRelayCommand(resetRecipe);
            SaveRecipeCommand = new AsyncRelayCommand(saveRecipe);

            AddStepCommand = new RelayCommand(addStep);
            DeleteStepCommand = new RelayCommand<Step>(deleteStep);

            AddIngredientCommand = new AsyncRelayCommand(addIngredient);
            DeleteIngredientCommand = new RelayCommand<Ingredient>(deleteIngredient);
        }

        #region Preparations
        private void getCourseList()
        {
            CourseList = Enum.GetValues<Course>()
                             .Select(CourseListItem.FromCourse);
        }
        /// <summary>
        /// Sets up list of possible courses for the recipe
        /// </summary>
        public IRelayCommand GetCourseListCommand { get; private set; }

        private void getIngredientTypesList()
        {
            IngredientTypeList = Enum.GetValues<IngredientType>()
                                     .Select(IngredientTypeListItem.FromIngredientType);
        }
        public IRelayCommand GetIngredientTypesListCommand { get; private set; }

        private void updateAllIngedientList(IngredientType ingredientType)
        {
            AllIngredientList = new ObservableCollection<string>(ingredientRepository.GetByType(ingredientType)
                                                                                     .Select(c => c.Name));
            SelectedIngredientName = AllIngredientList.FirstOrDefault();
        }
        #endregion

        #region Recipes
        private async Task resetRecipe()
        {
            Recipe = await recipeFactory.DefaultRecipe();
            StepList = [];
            IngredientList = [];
        }
        /// <summary>
        /// Resets recipe to a default state
        /// </summary>
        public IAsyncRelayCommand ResetRecipeCommand { get; private set; }

        private async Task saveRecipe()
        {
            Recipe.Ingredients = IngredientList;
            Recipe.Steps = StepList;
            await recipeRepository.Add(Recipe);
        }
        /// <summary>
        /// Adds recipe to database
        /// </summary>
        public IAsyncRelayCommand SaveRecipeCommand { get; private set; }
        #endregion

        #region Steps
        private void addStep()
        {
            StepList.Add(stepFactory.DefaultStep());
        }
        /// <summary>
        /// Adds a new step to recipe
        /// </summary>
        public IRelayCommand AddStepCommand { get; private set; }

        private void deleteStep(Step step)
        {
            StepList.Remove(step);
        }
        public IRelayCommand<Step> DeleteStepCommand { get; private set; }
        #endregion

        #region Ingredients
        private async Task addIngredient()
        {
            if (!string.IsNullOrEmpty(SelectedIngredientName))
            {
                IngredientList.Add(await ingredientRepository.GetByName(SelectedIngredientName));
            }
            //reset after adding
            SelectedIngredientName = null;
        }
        /// <summary>
        /// Adds a new ingredient to recipe
        /// </summary>
        public IAsyncRelayCommand AddIngredientCommand { get; private set; }

        private void deleteIngredient(Ingredient ingredient)
        {
            IngredientList.Remove(ingredient);
        }
        /// <summary>
        /// Deletes ingredient from recipe
        /// </summary>
        public IRelayCommand<Ingredient> DeleteIngredientCommand { get; private set; }
        #endregion
    }
}
