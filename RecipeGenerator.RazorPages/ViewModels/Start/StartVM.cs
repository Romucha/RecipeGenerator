using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeGenerator.API.Database.Recipes;
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

        public StartVM(IRecipeRepository recipeRepository, IRecipeFactory recipeFactory, IStepFactory stepFactory)
        {
            this.recipeRepository = recipeRepository; ;
            this.recipeFactory = recipeFactory;
            this.stepFactory = stepFactory;
            ResetRecipeCommand = new AsyncRelayCommand(resetRecipe);
            AddRecipeCommand = new AsyncRelayCommand(addRecipe);
            SetCourseListCommand = new RelayCommand(setCourseList);
            AddStepCommand = new RelayCommand(addStep);
        }

        private async Task resetRecipe()
        {
            Recipe = await recipeFactory.DefaultRecipe();
        }

        public IAsyncRelayCommand ResetRecipeCommand { get; private set; }


        private async Task addRecipe()
        {
            await recipeRepository.Add(recipe);
        }

        public IAsyncRelayCommand AddRecipeCommand { get; private set; }

        private void setCourseList()
        {
            CourseList = Enum.GetValues<Course>().Select(CourseListItem.FromCourse);
        }

        public IRelayCommand SetCourseListCommand { get; private set; }

        private void addStep()
        {
            Recipe.Steps?.Add(stepFactory.DefaultStep());
        }

        public IRelayCommand AddStepCommand { get; private set; }
    }
}
