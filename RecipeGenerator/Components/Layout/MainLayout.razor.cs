using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        public MainViewModel ViewModel { get; set; } = default!;

        [Inject]
        public ProgressViewModel ProgressViewModel { get; set; } = default!;

        [Inject]
        public IStringLocalizer<MainLayout> StringLocalizer { get; set; } = default!;

        [Inject]
        public DynamicLocalizationService DynamicLocalizationService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            DynamicLocalizationService.PropertyChanged += (sender, e) => StateHasChanged();
            DynamicLocalizationService.Initialize();

            ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
            ProgressViewModel.PropertyChanged += (sender, e) => StateHasChanged();
            await ViewModel.InitializeAsync();
        }
    }
}
