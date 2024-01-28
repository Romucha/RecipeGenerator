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

        private ObservableCollection<GetRecipeDTO> recipes;
        public ObservableCollection<GetRecipeDTO> Recipes 
        {
            get => recipes;
            set => SetProperty(ref recipes, value);
        }

        public IAsyncRelayCommand GetRecipesCommand => new AsyncRelayCommand(getRecipes);

        public IAsyncRelayCommand DeleteRecipeCommand => new AsyncRelayCommand<DeleteRecipeDTO>(deleteRecipe);

        public HomeVM(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        private async Task getRecipes()
        {
            Recipes = new ObservableCollection<GetRecipeDTO>(await recipeRepository.GetAll());
        }

        private async Task deleteRecipe(DeleteRecipeDTO deleteRecipeDTO)
        {
            await recipeRepository.Delete(deleteRecipeDTO);
            await getRecipes();
        }
    }
}
