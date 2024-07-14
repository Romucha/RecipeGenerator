using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Models.Steps
{
    /// <summary>
    /// A step in a recipe.
    /// </summary>
    public class Step : IRecipeGeneratorEntity
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
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Counter.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// List of photos.
        /// </summary>
        public List<string> Photos { get; set; } = [];

        /// <summary>
        /// Id of parent recipe.
        /// </summary>
        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }

        /// <summary>
        /// Parent recipe.
        /// </summary>
        public Recipe Recipe { get; set; } = default!;
    }
}
