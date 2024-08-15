using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.ViewModels.Details.Ingredients;

namespace RecipeGenerator.Views.Details.Ingredients
{
    public partial class DetailsIngredientView
    {
        [Inject]
        public DetailsIngredientViewModel ViewModel { get; set; } = default!;

        [Inject]
        public IStringLocalizer<DetailsIngredientView> StringLocalizer { get; set; } = default!;

        [Inject]
        public DynamicLocalizationService DynamicLocalizationService { get; set; } = default!;

        [Parameter]
        public Guid Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                await ViewModel.GetIngredientAsync(Id);
            }
            if (DynamicLocalizationService != null)
            {
                DynamicLocalizationService.PropertyChanged += (sender, e) => StateHasChanged();
            }
        }
    }
}
