using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.ViewModels.Home
{
    public class HomeVM : ObservableObject
    {
        private readonly IRecipeRepository recipeRepository;

        private IEnumerable<GetRecipeDTO> recipes;

        public IEnumerable<GetRecipeDTO> Recipes
        {
            get => recipes;
            set => SetProperty(ref recipes, value);
        }

        public HomeVM(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
            GetRecipesCommand = new AsyncRelayCommand(getRecipes);
        }

        private async Task getRecipes()
        {
            Recipes = await recipeRepository.GetAll();
        }

        public IAsyncRelayCommand GetRecipesCommand { get; private set; }
    }
}
