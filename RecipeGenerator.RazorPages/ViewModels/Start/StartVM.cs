using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Models.Recipes;
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

        private Recipe recipe;

        public Recipe Recipe
        {
            get => recipe;
            set => SetProperty(ref recipe, value);
        }

        public StartVM(IRecipeRepository recipeRepository, IRecipeFactory recipeFactory)
        {
            this.recipeRepository = recipeRepository;
            ResetRecipeCommand = new AsyncRelayCommand(resetRecipe);
            AddRecipeCommand = new AsyncRelayCommand(addRecipe);
            this.recipeFactory = recipeFactory;
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
    }
}
