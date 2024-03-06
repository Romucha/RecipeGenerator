using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.RazorPages.ViewModels.Add.AddRecipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Add.AddRecipe.CourseType
{
    public partial class CourseTypeView
    {
        [CascadingParameter]
        public AddRecipeVM AddVM { get; set; }
    }
}
