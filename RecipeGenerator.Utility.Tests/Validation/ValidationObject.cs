using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation
{
    public class ValidationObject
    {
        [Required]
        public string? Name { get; set; } = default!;

        [Required(AllowEmptyStrings = true)]
        public string? Description { get; set; } = default!;

        [Range(0, 1)]
        public double Coefficient { get; set; }

        [Range(0, 100, MinimumIsExclusive = true)]
        public int Index { get; set; }

        public static ValidationObject Normal => new()
        {
            Name = "Name",
            Description = "Description",
            Coefficient = 1,
            Index = 1
        };

        public static ValidationObject Normal_Description_Empty => new()
        {
            Name = "Name",
            Description = "",
            Coefficient = 1,
            Index = 1
        };

        public static ValidationObject Invalid_Name_Empty => new()
        {
            Name = "",
            Description = "Description",
            Coefficient = 1,
            Index = 1
        };

        public static ValidationObject Invalid_Name_Null => new()
        {
            Name = null,
            Description = "Description",
            Coefficient = 1,
            Index = 1
        };

        public static ValidationObject Invalid_Description_Null => new()
        {
            Name = "Name",
            Description = null,
            Coefficient = 1,
            Index = 1
        };

        public static ValidationObject Invalid_Coefficient_Negative => new()
        {
            Name = "Name",
            Description = "Description",
            Coefficient = -1,
            Index = 1
        };

        public static ValidationObject Invalid_Coefficient_ExceedsMaximum => new()
        {
            Name = "Name",
            Description = "Description",
            Coefficient = 10,
            Index = 1
        };

        public static ValidationObject Invalid_Index_Negative => new()
        {
            Name = "Name",
            Description = "Description",
            Coefficient = 1,
            Index = -1
        };

        public static ValidationObject Invalid_Index_Minimum => new()
        {
            Name = "Name",
            Description = "Description",
            Coefficient = 1,
            Index = 0
        };

        public static ValidationObject Invalid_Index_ExceedsMaximum => new()
        {
            Name = "Name",
            Description = "Description",
            Coefficient = 1,
            Index = 1000
        };

        public static ValidationObject Invalid_Default => new();

        public static ValidationObject? Invalid_Null => null;
    }
}
