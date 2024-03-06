using Microsoft.AspNetCore.Components;
using RecipeGenerator.RazorPages.ViewModels.Add.AddRecipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Add.AddRecipe.Save
{
    public partial class SaveView
    {
        [CascadingParameter]
        public AddRecipeVM AddVM { get; set; }
    }
}
