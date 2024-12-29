using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Data.Models
{
    public static class ApplicableIngredientData
    {
        public static ApplicableIngredient Default => new();

        public static ApplicableIngredient? Null => null;

        public static ApplicableIngredient Normal => new()
        {
            Id = 1,
            Name = nameof(Normal),
            Description = nameof(Normal),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IngredientType = IngredientType.Meat,
            Image = Properties.Resources.ApplicableIngredientNormal,
            Link = new Uri("https://google.com"),
            MeasurementType = RecipeGenerator.Models.Measurements.MeasurementType.Weight,
        };

        public static ApplicableIngredient Invalid => new()
        {
            Id = 0,
            Name = null!,
            Description = null!,
            CreatedAt = default,
            UpdatedAt = default,
            IngredientType = IngredientType.None,
            Image = null!,
            Link = null,
            MeasurementType = RecipeGenerator.Models.Measurements.MeasurementType.None,
        };
    }
}
