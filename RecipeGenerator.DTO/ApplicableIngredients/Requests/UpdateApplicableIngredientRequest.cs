namespace RecipeGenerator.DTO.ApplicableIngredients.Requests
{
    public record UpdateApplicableIngredientRequest
    {
        /// <summary>
        /// Idetifier.
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
        /// Link to an internet page about the ingredient.
        /// </summary>
        public Uri? Link { get; set; }

        /// <summary>
        /// Ingredient type.
        /// </summary>
        public int? IngredientType { get; set; }

        /// <summary>
        /// Image of the ingredient.
        /// </summary>
        public byte[]? Image { get; set; }
    }
}
