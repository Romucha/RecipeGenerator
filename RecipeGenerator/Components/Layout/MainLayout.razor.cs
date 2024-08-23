using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
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
        public IStringLocalizer<MainLayout> StringLocalizer { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
            await ViewModel.InitializeAsync();
        }
    }
}
