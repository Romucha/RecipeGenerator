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
    }
}
