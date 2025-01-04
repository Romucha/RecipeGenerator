using RecipeGenerator.Models.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Data.Models
{
    public static class MeasurementData
    {
        public static Measurement Default => new();

        public static Measurement? Null => null;

        public static Measurement Normal => new()
        {
            Id = 1,
            Name = nameof(Measurement),
            Description = nameof(Measurement),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            ConversionCoefficient = 1,
            Ingredients = new(),
            IsBase = true,
            MeasurementType = MeasurementType.Weight,
        };

        public static Measurement Invalid => new()
        {
            Id = 0,
            Name = null,
            Description = null,
            CreatedAt = default,
            UpdatedAt = default,
            ConversionCoefficient = 0,
            Ingredients = null,
            IsBase = true,
            MeasurementType = MeasurementType.None,
        };
    }
}
