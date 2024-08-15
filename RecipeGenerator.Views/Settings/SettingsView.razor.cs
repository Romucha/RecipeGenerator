using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.ViewModels.Settings;

namespace RecipeGenerator.Views.Settings
{
    public partial class SettingsView
    {
        [Inject]
        public SettingsViewModel ViewModel { get; set; } = default!;

        [Inject]
        public IStringLocalizer<SettingsView> StringLocalizer { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                if (ViewModel.DynamicLocalizationService != null)
                {
                    ViewModel.DynamicLocalizationService.PropertyChanged += async (sender, e) => await InvokeAsync(StateHasChanged);
                    currentCulture = ViewModel.DynamicLocalizationService.CurrentCulture;
                }
                ViewModel.PropertyChanged += async (sender, e) => await InvokeAsync(StateHasChanged);
                await ViewModel.InitializeAsync();
            }
        }

        private string currentCulture = default!;
    }
}
