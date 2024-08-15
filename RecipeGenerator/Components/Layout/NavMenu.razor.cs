using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.Localization.Services;

namespace RecipeGenerator.Components.Layout
{
    public partial class NavMenu
    {
        [Inject]
        public IStringLocalizer<NavMenu> StringLocalizer { get; set; } = default!;

        [Inject]
        public DynamicLocalizationService DynamicLocalizationService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if (DynamicLocalizationService != null)
            {
                DynamicLocalizationService.PropertyChanged += (sender, e) => StateHasChanged();
            }
            await base.OnInitializedAsync();
        }
    }
}
