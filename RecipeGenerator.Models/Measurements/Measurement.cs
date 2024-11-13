using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Models.Measurements
{
    /// <summary>
    /// Measurement of an applicable ingredient.
    /// </summary>
    public class Measurement : IRecipeGeneratorEntity
    {
        /// <inheritdoc/>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public Guid Id { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <inheritdoc/>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

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
        /// Value of the measurement.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Determines if the measurement is base.
        /// </summary>
        public bool IsBase { get; set; }

        /// <summary>
        /// Coefficient of conversion.
        /// </summary>
        public double ConversionCoefficient { get; set; }
    }
}
