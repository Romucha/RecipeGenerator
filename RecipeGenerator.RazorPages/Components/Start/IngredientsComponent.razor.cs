using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.RazorPages.ViewModels.Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Components.Start
{
    public partial class IngredientsComponent
    {
        [CascadingParameter]
        public StartVM StartVM { get; set; }
    }
}
