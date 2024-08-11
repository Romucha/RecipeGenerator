using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.ViewModels.List.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.List.Recipes
{
    public partial class ListRecipesView
    {
        [Inject]
        public ListRecipesViewModel ViewModel { get; set; } = default!;

        [Inject]
        public IStringLocalizer<ListRecipesView> StringLocalizer { get; set; } = default!;

        [Inject]
        public DynamicLocalizationService? DynamicLocalizationService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if (DynamicLocalizationService != null)
            {
                DynamicLocalizationService.PropertyChanged += (sender, e) => StateHasChanged();
            }
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                await ViewModel.GetRecipesAsync();
            }
        }
    }
}
