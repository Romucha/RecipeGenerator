﻿using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Data
{
    internal class RecipeData : IValidationTestData<Recipe>
    {
        public Recipe Default => new Recipe();

        public Recipe? Null => null;

        public Recipe Normal => new Recipe()
        {
            Id = 1,
            CourseType = Course.Horsdoeuvres,
            Name = nameof(Normal),
            Description = nameof(Normal),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            EstimatedTime = TimeSpan.FromDays(1),
            Image = Properties.Resources.RecipeNormal,
            Portions = 10,
            Steps = new(),
            Ingredients = new(),
        };

        public Recipe Invalid => new Recipe()
        {
            Id = 0,
            CourseType = Course.Unknown,
            Name = null!,
            Description = null!,
            CreatedAt = default,
            UpdatedAt = default,
            EstimatedTime = TimeSpan.FromMinutes(0),
            Image = null!,
            Portions = 0,
            Steps = null!,
            Ingredients = null!,
        };
    }
}
