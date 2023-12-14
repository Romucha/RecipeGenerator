using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.ViewModels.Explore
{
    public class ExploreVM : ObservableObject
    {
        private readonly IIngredientRepository ingredientRepository;

        public IAsyncRelayCommand GetIngredientsCommand { get; set; }

        public ExploreVM(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
            ingredients = new();

            GetIngredientsCommand = new AsyncRelayCommand(getIngredientsAsync);
        }

        private ObservableCollection<IngredientGroupVM> ingredients;

        public ObservableCollection<IngredientGroupVM> Ingredients
        {
            get => ingredients;
            set => SetProperty(ref ingredients, value);
        }

        private async Task getIngredientsAsync()
        {
            var ingredientTypes = Enum.GetValues<IngredientType>();
            List<IngredientGroupVM> ingredients = new();
            foreach (var ingType in ingredientTypes)
            {
                ingredients.Add(new IngredientGroupVM((await ingredientRepository.GetByType(ingType)).OrderBy(c => c.Name), ingType));
            }
            Ingredients = new ObservableCollection<IngredientGroupVM>(ingredients.OrderBy(c => c.DisplayName));
        }
    }
}
