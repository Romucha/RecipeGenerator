using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.App.ViewModels
{
    public class AboutVM : ObservableObject
    {
        private readonly IIngredientRepository ingredientRepository;

        public IAsyncRelayCommand GetIngredientsCommand { get; set; }

        public AboutVM(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
            this.ingredients = new();

            this.GetIngredientsCommand = new AsyncRelayCommand(getIngredientsAsync);
        }

        private Dictionary<IngredientType, ObservableCollection<IIngredient>> ingredients;

        public Dictionary<IngredientType, ObservableCollection<IIngredient>> Ingredients
        {
            get => ingredients;
            set => SetProperty(ref ingredients, value);
        }

        private async Task getIngredientsAsync()
        {
            foreach (var type in Enum.GetValues<IngredientType>())
            {
                Ingredients.Add(type, new ObservableCollection<IIngredient>((await ingredientRepository.GetByType(type)).OrderBy(c => c.Name)));
            }
        }
    }
}
