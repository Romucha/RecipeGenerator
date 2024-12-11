using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.ViewModels.Details.Recipes;

namespace RecipeGenerator.Views.Details.Recipes
{
    public partial class DetailsRecipeView
    {
        [Inject]
        public DetailsRecipeViewModel ViewModel { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

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
