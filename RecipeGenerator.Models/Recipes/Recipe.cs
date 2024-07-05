using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.Models.Ingredients;

namespace RecipeGenerator.Models.Recipes
{
    /// <summary>
    /// Recipe.
    /// </summary>
    public class Recipe : IRecipeGeneratorNamedModel
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
        /// Image.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Course type.
        /// </summary>
        public Course CourseType { get; set; }

        /// <summary>
        /// Approximate time to cook the dish.
        /// </summary>
        public TimeSpan EstimatedTime { get; set; }

        /// <summary>
        /// Number of portions.
        /// </summary>
        public int Portions { get; set; }

        /// <summary>
        /// List of steps.
        /// </summary>
        public List<Step> Steps { get; set; } = new();

        /// <summary>
        /// List of ingredients.
        /// </summary>
        public List<AppliedIngredient> Ingredients { get; set; } = new();

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Date of the last update.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
