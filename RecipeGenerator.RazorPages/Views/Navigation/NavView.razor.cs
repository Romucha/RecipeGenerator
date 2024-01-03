using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Navigation
{
    public partial class NavView
    {
        [Parameter]
        public string NavPath { get; set; }

        [Parameter]
        public string OiIcon { get; set; }

        [Parameter]
        public string OiTitle { get; set; }

        [Parameter]
        public bool IsBig { get; set; } = false;
    }
}
