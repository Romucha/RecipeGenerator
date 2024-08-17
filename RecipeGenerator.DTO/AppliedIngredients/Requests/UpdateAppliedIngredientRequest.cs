﻿namespace RecipeGenerator.DTO.AppliedIngredients.Requests
{
    public record UpdateAppliedIngredientRequest
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the source ingredient.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description of the source ingredient.
        /// </summary>
        public string? Description { get; set; }
    }
}