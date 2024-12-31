using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Data.Models
{
    public static class ApplicableIngredientDataCollections
    {
        public static List<ApplicableIngredient> Normal => new()
        {
            new()
            {
                Id = 1,
                Name = $"{nameof(Normal)}_1",
                Description = $"{nameof(Normal)}_1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IngredientType = IngredientType.Meat,
                Image = Properties.Resources.ApplicableIngredientNormal,
                Link = new Uri("https://google.com"),
                MeasurementType = RecipeGenerator.Models.Measurements.MeasurementType.Weight,
            },
            new()
            {
                Id = 2,
                Name = $"{nameof(Normal)}_2",
                Description = $"{nameof(Normal)}_2",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IngredientType = IngredientType.Fruits,
                Image = Properties.Resources.ApplicableIngredientNormal,
                Link = new Uri("https://google.com"),
                MeasurementType = RecipeGenerator.Models.Measurements.MeasurementType.Amount,
            },
            new()
            {
                Id = 3,
                Name = $"{nameof(Normal)}_3",
                Description = $"{nameof(Normal)}_3",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IngredientType = IngredientType.DairyProducts,
                Image = Properties.Resources.ApplicableIngredientNormal,
                Link = new Uri("https://google.com"),
                MeasurementType = RecipeGenerator.Models.Measurements.MeasurementType.Volume,
            }
        };
    }
}
