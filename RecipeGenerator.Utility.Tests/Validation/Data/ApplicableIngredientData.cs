using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Data
{
    internal class ApplicableIngredientData : IValidationTestData<ApplicableIngredient>
    {
        public ApplicableIngredient Default => new();

        public ApplicableIngredient? Null => null;

        public ApplicableIngredient Normal => new()
        {
            Id = 1,
            Name = nameof(Normal),
            Description = nameof(Normal),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IngredientType = IngredientType.Meat,
            Image = Properties.Resources.ApplicableIngredientNormal,
            Link = new Uri("https://google.com"),
            MeasurementType = Models.Measurements.MeasurementType.Weight,
        };

        public ApplicableIngredient Invalid => new()
        {
            Id = 0,
            Name = null!,
            Description = null!,
            CreatedAt = default,
            UpdatedAt = default,
            IngredientType = IngredientType.None,
            Image = null!,
            Link = null,
            MeasurementType = Models.Measurements.MeasurementType.None,
        };
    }
}
