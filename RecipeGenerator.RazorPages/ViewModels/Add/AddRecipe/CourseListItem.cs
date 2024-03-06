using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Properties.Recipes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.ViewModels.Add.AddRecipe
{
    public class CourseListItem
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public Course Value { get; set; }

        public static CourseListItem FromCourse(Course course)
        {
            var courseItem = new CourseListItem();

            ResourceManager resourceManagerNames = new ResourceManager(typeof(CourseNames));
            ResourceSet resourceSetNames = resourceManagerNames.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            ResourceManager resourceManagerDescriptions = new ResourceManager(typeof(CourseDescriptions));
            ResourceSet resourceSetDescriptions = resourceManagerDescriptions.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            courseItem.Value = course;
            courseItem.DisplayName = resourceSetNames.GetString(course.ToString(), true);
            courseItem.Description = resourceSetDescriptions.GetString(course.ToString(), true);

            return courseItem;
        }
    }
}
