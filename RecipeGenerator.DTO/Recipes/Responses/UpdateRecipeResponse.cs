namespace RecipeGenerator.DTO.Recipes.Responses
{
    public record UpdateRecipeResponse
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

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
        public byte[]? Image { get; set; } = [];

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
