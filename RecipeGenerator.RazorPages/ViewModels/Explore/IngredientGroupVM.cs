using CommunityToolkit.Mvvm.ComponentModel;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.ViewModels.Explore
{
    public class IngredientGroupVM : ObservableObject
    {
        private ObservableCollection<Ingredient> ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get => ingredients;
            set => SetProperty(ref ingredients, value);
        }

        private string displayName;
        public string DisplayName
        {
            get => displayName;
            set => SetProperty(ref displayName, value);
        }

        private IngredientType ingredientType;
        public IngredientType IngredientType
        {
            get => ingredientType;
            set => SetProperty(ref ingredientType, value);
        }

        private bool isExpanded;
        public bool IsExpanded
        {
            get => isExpanded;
            set => SetProperty(ref isExpanded, value);
        }

        public IngredientGroupVM(IEnumerable<Ingredient> ingredients, IngredientType ingredientType)
        {
            Ingredients = new ObservableCollection<Ingredient>(ingredients);
            IngredientType = ingredientType;
            DisplayName = ingredientType.ToDisplayName();
            IsExpanded = false;
        }
    }
}
