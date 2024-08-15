using RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests;
using RecipeGenerator.DTO.Implementations.Steps.Requests;
using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.Recipes.Requests
{
    public record UpdateRecipeRequest : IUpdateRequest
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
        public byte[]? Image { get; set; }

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
