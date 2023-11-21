using CommunityToolkit.Mvvm.ComponentModel;
using RecipeGenerator.API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.App.ViewModels
{
    internal class MainVM : ObservableObject
    {
        public MainVM() { }

        private ObservableCollection<Recipe> recipes;

        public ObservableCollection<Recipe> Recipes
        {
            get => recipes;
            set => SetProperty(ref recipes, value);
        }
    }
}
