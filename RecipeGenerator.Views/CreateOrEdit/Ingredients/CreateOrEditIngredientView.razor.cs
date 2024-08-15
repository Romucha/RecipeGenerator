using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.CreateOrEdit.Ingredients;

namespace RecipeGenerator.Views.Create.Ingredients
{
    public partial class CreateOrEditIngredientView
    {
        [Inject]
        public CreateOrEditIngredientViewModel ViewModel { get; set; } = default!;
    }
}
