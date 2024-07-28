using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.List.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.List.Recipes
{
    public partial class ListRecipesView
    {
        [Inject]
        public ListRecipesViewModel ViewModel { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                await ViewModel.GetRecipesAsync();
            }
        }
    }
}
