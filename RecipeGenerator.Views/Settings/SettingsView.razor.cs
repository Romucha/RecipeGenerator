using Microsoft.AspNetCore.Components;
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

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                await ViewModel.InitializeAsync();
            }
        }
    }
}
