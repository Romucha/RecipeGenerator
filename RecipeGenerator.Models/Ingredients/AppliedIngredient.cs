using RecipeGenerator.Models.Recipes;
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
    /// Ingredient applied to a recipe.
    /// </summary>
    public class AppliedIngredient : IRecipeGeneratorEntity
    {
        /// <inheritdoc/>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public Guid Id { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <inheritdoc/>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of a parent recipe.
        /// </summary>
        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }

        /// <summary>
        /// Parent recipe.
        /// </summary>
        public Recipe Recipe { get; set; } = default!;

        /// <summary>
        /// Identifier of a base ingredient.
        /// </summary>
        [ForeignKey(nameof(Ingredient))]
        public Guid IngredientId { get; set; }

        /// <summary>
        /// Base ingredient.
        /// </summary>
        public ApplicableIngredient? Ingredient { get; set; } = default!;
    }
}
