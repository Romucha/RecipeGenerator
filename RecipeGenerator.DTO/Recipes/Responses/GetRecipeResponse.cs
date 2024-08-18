namespace RecipeGenerator.DTO.Recipes.Responses
{
    public record GetRecipeResponse
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date of the last update.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Display name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Image.
        /// </summary>
        public byte[] Image { get; set; } = [];

        /// <summary>
        /// Course type.
        /// </summary>
        public int CourseType { get; set; }

        /// <summary>
        /// Approximate time to cook the dish.
        /// </summary>
        public TimeSpan EstimatedTime { get; set; }

        /// <summary>
        /// Number of portions.
        /// </summary>
        public int Portions { get; set; }
    }
}
