﻿namespace RecipeGenerator.DTO.AppliedIngredients.Responses
{
    public record GetAppliedIngredientResponse
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

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
