using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Data.Models
{
    public static class RecipeDataCollections
    {
        public static List<Recipe> Normal => new()
        {
            new()
            {
                Id = 1,
                Name = $"{nameof(Normal)}_1",
                Description = $"{nameof(Normal)}_1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CourseType = Course.Horsdoeuvres,
                EstimatedTime = TimeSpan.FromDays(1),
                Portions = 10,
                Image = Properties.Resources.RecipeNormal,
            },
            new()
            {
                Id = 2,
                Name = $"{nameof(Normal)}_2",
                Description = $"{nameof(Normal)}_2",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CourseType = Course.Soup,
                EstimatedTime = TimeSpan.FromHours(2),
                Portions = 15,
                Image = Properties.Resources.RecipeNormal,
            },
            new()
            {
                Id = 3,
                Name = $"{nameof(Normal)}_3",
                Description = $"{nameof(Normal)}_3",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CourseType = Course.FirstMainDish,
                EstimatedTime = TimeSpan.FromHours(3),
                Portions = 7,
                Image = Properties.Resources.RecipeNormal,
            },
        };
    }
}
