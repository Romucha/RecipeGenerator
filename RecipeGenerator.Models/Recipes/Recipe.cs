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
    public class Recipe
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public Guid Id { get; set; }

        /// <summary>
        /// Display name.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Image.
        /// </summary>
        public string Image { get; set; } = default!;

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; } = default!;

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
        public List<Step> Steps { get; set; } = default!;

        /// <summary>
        /// List of ingredients.
        /// </summary>
        public List<AppliedIngredient> Ingredients { get; set; } = default!;

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date of the last update.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
