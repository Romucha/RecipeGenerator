using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeGenerator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.ViewModels.Start
{
    public class StartVM : ObservableObject
    {
        private Recipe recipe;

        public Recipe Recipe
        {
            get => recipe;
            set => SetProperty(ref recipe, value);
        }

        public StartVM()
        {
            ResetRecipeCommand = new RelayCommand(resetRecipe);
        }

        private void resetRecipe()
        {
            Recipe = new Recipe();
        }

        public IRelayCommand ResetRecipeCommand { get; private set; }
    }
}
