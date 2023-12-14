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

        private Recipe recipe;

        public Recipe Recipe
        {
            get => recipe;
            set => SetProperty(ref recipe, value);
        }

        public StartVM(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
            ResetRecipeCommand = new RelayCommand(resetRecipe);
            AddRecipeCommand = new AsyncRelayCommand(addRecipe);
        }

        private void resetRecipe()
        {
            Recipe = new Recipe();
        }

        public IRelayCommand ResetRecipeCommand { get; private set; }

        private async Task addRecipe()
        {
            await recipeRepository.Add(recipe);
        }

        public IAsyncRelayCommand AddRecipeCommand { get; private set; }
    }
}
