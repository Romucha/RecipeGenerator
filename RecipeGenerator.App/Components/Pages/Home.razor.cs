using Microsoft.AspNetCore.Components;
using RecipeGenerator.App.ViewModels;
using RecipeGenerator.RazorPages.Components.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.App.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private HomeVM homeVM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            homeVM.GetRecipesCommand.Execute(null);
            
            await base.OnInitializedAsync();
        }
    }
}
