using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.DTO.AppliedIngredients.Requests;
using RecipeGenerator.DTO.Steps.Requests;

namespace RecipeGenerator.DTO.Recipes.Requests
{
    public record UpdateRecipeRequest
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Display name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Image.
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// Course type.
        /// </summary>
        public int? CourseType { get; set; }

        /// <summary>
        /// Approximate time to cook the dish.
        /// </summary>
        public TimeSpan? EstimatedTime { get; set; }

        /// <summary>
        /// Number of portions.
        /// </summary>
        public int? Portions { get; set; }

        /// <summary>
        /// List of steps.
        /// </summary>
        public List<UpdateStepRequest?>? Steps { get; set; }

        /// <summary>
        /// List of ingredients.
        /// </summary>
        public List<UpdateAppliedIngredientRequest?>? Ingredients { get; set; }
    }
}
