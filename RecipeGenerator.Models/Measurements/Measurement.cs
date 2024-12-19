using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.Models.Ingredients;

namespace RecipeGenerator.Models.Measurements
{
    /// <summary>
    /// Measurement of an applicable ingredient.
    /// </summary>
    public class Measurement : IRecipeGeneratorEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; }

        /// <inheritdoc/>
        public DateTime UpdatedAt { get; set; }

        /// <inheritdoc/>
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Type of the measurement.
        /// </summary>
        public MeasurementType Type { get; set; }

        /// <summary>
        /// Determines if the measurement is base.
        /// </summary>
        public bool IsBase { get; set; }

        /// <summary>
        /// Coefficient of conversion.
        /// </summary>
        public double ConversionCoefficient { get; set; }

        /// <summary>
        /// List of ingredients.
        /// </summary>
        public List<AppliedIngredient> Ingredients { get; set; } = new();
    }
}
