using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Components.Home
{
    public class HomeVM : ObservableObject
    {
        private readonly IRecipeRepository recipeRepository;

        private IQueryable<Recipe> recipes;

        public IQueryable<Recipe> Recipes
        {
            get => recipes;
            set => SetProperty(ref recipes, value);
        }

        public HomeVM(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
            this.GetRecipesCommand = new RelayCommand(getRecipes);
        }

        private void getRecipes()
        {
            Recipes = recipeRepository.GetAll() as IQueryable<Recipe>;
        }

        public IRelayCommand GetRecipesCommand { get; private set; }
    }
}
