﻿using RecipeGenerator.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Data.Models
{
    public static class AppliedIngredientDataCollections
    {
        public static List<AppliedIngredient> Normal => new()
        {
            new()
            {
                Id = 1,
                Name = $"{nameof(Normal)}_1",
                Description = $"{nameof(Normal)}_1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 1,
                MeasurementValue = 0.5,
                IngredientId = 1,
                MeasurementId = 1,
            },
            new()
            {
                Id = 2,
                Name = $"{nameof(Normal)}_2",
                Description = $"{nameof(Normal)}_2",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 1,
                MeasurementValue = 3,
                IngredientId = 2,
                MeasurementId = 2,
            },
            new()
            {
                Id = 3,
                Name = $"{nameof(Normal)}_3",
                Description = $"{nameof(Normal)}_3",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RecipeId = 1,
                MeasurementValue = 7.7,
                IngredientId = 3,
                MeasurementId = 3,
            },
        };
    }
}
