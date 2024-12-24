using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Data
{
    internal static class StepData
    {
        public static Step Default => new();

        public static Step? Null => null;

        public static Step Normal => new()
        {
            Id = 1,
            Name = nameof(Normal),
            Description = nameof(Normal),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Index = 1,
            Photos = new() { Properties.Resources.StepNormal },
            RecipeId = 1,
        };

        public static Step Invalid => new()
        {
            Id = 0,
            Name = null!,
            Description = null!,
            CreatedAt = default,
            UpdatedAt = default,
            Index = 0,
            Photos = null!,
            RecipeId = 0,
            Recipe = null,
        };
    }
}
