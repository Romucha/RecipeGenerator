﻿namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests
{
    public record UpdateAppliedIngredientRequest
    {
        /// <summary>
        /// Name of the source ingredient.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Description of the source ingredient.
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// Identifier of a parent recipe.
        /// </summary>
        public Guid? RecipeId { get; set; }

        /// <summary>
        /// Identifier of a base ingredient.
        /// </summary>
        public Guid? IngredientId { get; set; }
    }
}
