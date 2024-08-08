using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                await ViewModel.InitializeAsync();
                if (ViewModel.DynamicLocalizationService != null)
                {
                    ViewModel.DynamicLocalizationService.PropertyChanged += (sender, e) => StateHasChanged();
                }
            }
            var strings = StringLocalizer.GetAllStrings();
        }

        private string currentCulture = default!;
    }
}
