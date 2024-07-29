using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.Create.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.Create.Recipes
{
    public partial class CreateRecipeView
    {
        [Inject]
        public CreateRecipeViewModel ViewModel { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                await ViewModel.GetApplicableIngredientsAsync();
            }

            await base.OnInitializedAsync();
        }
    }
}
