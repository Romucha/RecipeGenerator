using RecipeGenerator.Models.Measurements;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeGenerator.Models.Ingredients
{
    /// <summary>
    /// Ingredient ready to be applied to a recipe.
    /// </summary>
    public class ApplicableIngredient : IRecipeGeneratorEntity
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
        /// Link to an internet page about the ingredient.
        /// </summary>
        public Uri? Link { get; set; } = default!;

        /// <summary>
        /// Ingredient type.
        /// </summary>
        public IngredientType IngredientType { get; set; }

        /// <summary>
        /// Image of the ingredient.
        /// </summary>
        public byte[] Image { get; set; } = [];

        /// <summary>
        /// Measurement type.
        /// </summary>
        public MeasurementType MeasurementType { get; set; }
    }
}
