using Microsoft.AspNetCore.Components;
using RecipeGenerator.RazorPages.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Home
{
    public partial class HomeView
    {
        [Inject]
        public HomeVM HomeVM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            HomeVM.PropertyChanged += (sender, e) => StateHasChanged();
            HomeVM.GetRecipesCommand.Execute(null);

            await base.OnInitializedAsync();
        }
    }
}
