using Microsoft.AspNetCore.Components;
using RecipeGenerator.RazorPages.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Home.Tables
{
    public partial class DisplayView
    {
        [Parameter]
        public HomeVM HomeVM { get; set; }
    }
}
