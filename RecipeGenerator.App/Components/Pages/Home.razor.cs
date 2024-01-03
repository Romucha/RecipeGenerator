using Microsoft.AspNetCore.Components;
using RecipeGenerator.App.ViewModels;
using RecipeGenerator.RazorPages.ViewModels.Home;
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
        private HomeVM HomeVM { get; set; }
    }
}
