using RecipeGenerator.DTO.Base.Requests;

namespace RecipeGenerator.DTO.Recipes.Requests
{
    public record UpdateRecipeRequest : BaseUpdateRequest
    {
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
    }
}
