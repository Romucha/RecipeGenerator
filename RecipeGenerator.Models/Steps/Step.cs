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
    public class Step : IRecipeGeneratorModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public Guid Id { get; set; }

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
        /// Date of creation.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Date of last update.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

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
