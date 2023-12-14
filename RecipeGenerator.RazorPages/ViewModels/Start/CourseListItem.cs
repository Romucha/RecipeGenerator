using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.ViewModels.Start
{
    public class CourseListItem
    {
        public int DisplayName { get; set; }

        public string Description { get; set; }

        public Course Value { get; set; }
    }
}
