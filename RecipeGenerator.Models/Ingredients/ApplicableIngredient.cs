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
    public class ApplicableIngredient : IRecipeGeneratorModel
    {
        /// <summary>
        /// Idetifier.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public Guid Id { get; set; }

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
        /// Date of creation.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Date of last update.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Image of the ingredient.
        /// </summary>
        public string Image { get; set; } = string.Empty;
    }
}
