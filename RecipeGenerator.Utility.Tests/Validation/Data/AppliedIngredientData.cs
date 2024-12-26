using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Data
{
    internal class AppliedIngredientData : IValidationTestData<AppliedIngredient>
    {
        public AppliedIngredient Default => new AppliedIngredient();

        public AppliedIngredient? Null => null;

        public AppliedIngredient Normal => new AppliedIngredient()
        {
            Id = 1,
            IngredientId = 1,
            Name = nameof(AppliedIngredient),
            Description = nameof(AppliedIngredient),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            MeasurementId = 1,
            MeasurementType =Models.Measurements.MeasurementType.Amount,
            RecipeId = 1,
            MeasurementValue = 1,
        };

        public AppliedIngredient Invalid => new AppliedIngredient()
        {
            Id = 0,
            IngredientId = 0,
            Name = null,
            Description = null,
            CreatedAt = default,
            UpdatedAt = default,
            MeasurementId = 0,
            MeasurementType = Models.Measurements.MeasurementType.None,
            MeasurementValue = 0,
        };
    }
}
