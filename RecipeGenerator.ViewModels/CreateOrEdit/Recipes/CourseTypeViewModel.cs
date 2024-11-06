using Microsoft.Extensions.Localization;
using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.CreateOrEdit.Recipes
{
    public class CourseTypeViewModel
    {
        public CourseTypeViewModel(IStringLocalizer<Course> stringLocalizer, Course course) 
        {
            Course = course;
            Name= stringLocalizer[Course.ToString()];
        }

        public Course Course { get; set; }

        public string Name { get; set; } = default!;
    }
}
