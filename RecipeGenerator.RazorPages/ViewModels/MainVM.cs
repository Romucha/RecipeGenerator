using CommunityToolkit.Mvvm.ComponentModel;
using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.App.ViewModels
{
    public class MainVM : ObservableObject
    {
        public MainVM() { }

        private ObservableCollection<GetRecipeDTO> recipes;

        public ObservableCollection<GetRecipeDTO> Recipes
        {
            get => recipes;
            set => SetProperty(ref recipes, value);
        }
    }
}
