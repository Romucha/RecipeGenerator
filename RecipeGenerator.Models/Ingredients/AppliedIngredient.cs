using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Models.Recipes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeGenerator.Models.Ingredients
{
    /// <summary>
    /// Ingredient applied to a recipe.
    /// </summary>
    public class AppliedIngredient : IRecipeGeneratorEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; }

        /// <inheritdoc/>
        public DateTime UpdatedAt { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of a parent recipe.
        /// </summary>
        public int? RecipeId { get; set; }

        /// <summary>
        /// Parent recipe.
        /// </summary>
        public Recipe? Recipe { get; set; } = default!;

        /// <summary>
        /// Identifier of a base ingredient.
        /// </summary>
        public int? IngredientId { get; set; }

        /// <summary>
        /// Base ingredient.
        /// </summary>
        public ApplicableIngredient? ApplicableIngredient { get; set; } = default!;

        /// <summary>
        /// Type of a measurement that can be applied to the ingredient.
        /// </summary>
        public MeasurementType MeasurementType { get; set; }

        /// <summary>
        /// Identifier of a measurement.
        /// </summary>
        public int? MeasurementId { get; set; }

        /// <summary>
        /// Measurement.
        /// </summary>
        public Measurement? Measurement { get; set; } = default!;

        /// <summary>
        /// Value of the measurement.
        /// </summary>
        public double MeasurementValue { get; set; }

    }
}
