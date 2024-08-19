namespace RecipeGenerator.DTO.AppliedIngredients.Responses
{
    public record UpdateAppliedIngredientResponse
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of ingredient.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description of ingredient.
        /// </summary>
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Identifier of a parent recipe.
        /// </summary>
        public Guid RecipeId { get; set; }

        /// <summary>
        /// Identifier of a base ingredient.
        /// </summary>
        public Guid IngredientId { get; set; }
    }
}
