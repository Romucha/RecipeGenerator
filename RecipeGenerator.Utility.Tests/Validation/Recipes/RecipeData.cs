using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Recipes
{
    internal static class RecipeData
    {
        public static Recipe Default => new Recipe();

        public static Recipe? Null => null;

        public static Recipe Normal => new Recipe()
        {
            Id = 1,
            CourseType = Course.Horsdoeuvres,
            Name = nameof(Normal),
            Description = nameof(Normal),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            EstimatedTime = TimeSpan.FromDays(1),
            Image = Properties.Resources.Normal,
            Portions = 10,
            Steps = new(),
            Ingredients = new(),
        };
    }
}
