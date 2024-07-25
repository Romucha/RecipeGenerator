using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Models.Ingredients
{
    /// <summary>
    /// Ingredient ready to be applied to a recipe.
    /// </summary>
    public class ApplicableIngredient : IRecipeGeneratorEntity
    {
        /// <inheritdoc/>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public Guid Id { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <inheritdoc/>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Display name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description.
        /// </summary>
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
    }
}
