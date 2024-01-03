using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.RazorPages.ViewModels.Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Start.CourseType
{
    public partial class CourseTypeView
    {
        [CascadingParameter]
        public StartVM StartVM { get; set; }
    }
}
