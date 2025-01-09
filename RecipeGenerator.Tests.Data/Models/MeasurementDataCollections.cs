using RecipeGenerator.Models.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Data.Models
{
    public static class MeasurementDataCollections
    {
        public static List<Measurement> Normal => new()
        {
            new()
            {
                Id = 1,
                Name = $"{nameof(Normal)}_1",
                Description = $"{nameof(Normal)}_1",
                ConversionCoefficient = 1,
                IsBase = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                MeasurementType = MeasurementType.Weight,
                Ingredients = new()
            },
            new()
            {
                Id = 2,
                Name = $"{nameof(Normal)}_2",
                Description = $"{nameof(Normal)}_2",
                ConversionCoefficient = 2,
                IsBase = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                MeasurementType = MeasurementType.Volume,
                Ingredients = new()
            },
            new()
            {
                Id = 3,
                Name = $"{nameof(Normal)}_3",
                Description = $"{nameof(Normal)}_3",
                ConversionCoefficient = 0.9,
                IsBase = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                MeasurementType = MeasurementType.Spoon,
                Ingredients = new()
            }
        };
    }
}
