using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.Details.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.Details.Ingredients
{
    public partial class DetailsIngredientView
    {
        [Inject]
        public DetailsIngredientViewModel ViewModel { get; set; } = default!;

        [Parameter]
        public Guid Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                await ViewModel.GetIngredientAsync(Id);
            }
        }
    }
}
