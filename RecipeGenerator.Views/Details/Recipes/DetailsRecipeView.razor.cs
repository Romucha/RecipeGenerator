using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.ViewModels.Details.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.Details.Recipes
{
    public partial class DetailsRecipeView
    {
        [Inject]
        public DetailsRecipeViewModel ViewModel { get; set; } = default!;

        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        public IStringLocalizer<DetailsRecipeView> StringLocalizer { get; set; } = default!;

        [Inject]
        public DynamicLocalizationService DynamicLocalizationService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                await ViewModel.GetRecipeAsync(Id);
            }

            if (DynamicLocalizationService != null) 
            {
                DynamicLocalizationService.PropertyChanged += (sender, e) => StateHasChanged();
            }
        }
    }
}
