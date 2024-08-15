using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.ViewModels.List.Ingredients;

namespace RecipeGenerator.Views.List.Ingredients
{
    public partial class ListIngredientsView
    {
        [Inject]
        public ListIngredientsViewModel ViewModel { get; set; } = default!;

        [Inject]
        public IStringLocalizer<ListIngredientsView> StringLocalizer { get; set; } = default!;

        [Inject]
        public DynamicLocalizationService DynamicLocalizationService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                await ViewModel.GetIngredientsAsync();
            }
            if (DynamicLocalizationService != null)
            {
                DynamicLocalizationService.PropertyChanged += (sender, e) => StateHasChanged();
            }
        }
    }
}
