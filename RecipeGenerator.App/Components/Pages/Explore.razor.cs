using Microsoft.AspNetCore.Components;
using RecipeGenerator.RazorPages.ViewModels.About;
using RecipeGenerator.RazorPages.ViewModels.Explore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.App.Components.Pages
{
    public partial class Explore
    {
        [Inject]
        private ExploreVM ExploreVM { get; set; }
    }
}
