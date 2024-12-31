using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Data.Models
{
    public static class AppliedIngredientData
    {
        public static AppliedIngredient Default => new AppliedIngredient();

        public static AppliedIngredient? Null => null;

        public static AppliedIngredient Normal => new AppliedIngredient()
        {
            Id = 1,
            IngredientId = 1,
            Name = nameof(AppliedIngredient),
            Description = nameof(AppliedIngredient),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            MeasurementId = 1,
            RecipeId = 1,
            MeasurementValue = 1,
        };

        public static AppliedIngredient Invalid => new AppliedIngredient()
        {
            Id = 0,
            IngredientId = 0,
            Name = null,
            Description = null,
            CreatedAt = default,
            UpdatedAt = default,
            MeasurementId = 0,
            MeasurementValue = 0,
        };
    }
}
