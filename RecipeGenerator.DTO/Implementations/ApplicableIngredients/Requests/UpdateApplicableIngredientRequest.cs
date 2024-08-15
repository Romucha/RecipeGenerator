﻿using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests
{
    public record UpdateApplicableIngredientRequest : IUpdateRequest
    {
        /// <summary>
        /// Idetifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Display name.
        /// </summary>
        public string? Name { get; set; } = default!;

        /// <summary>
        /// Description.
        /// </summary>
        public string? Description { get; set; } = default!;

        /// <summary>
        /// Link to an internet page about the ingredient.
        /// </summary>
        public Uri? Link { get; set; } = default!;

        /// <summary>
        /// Ingredient type.
        /// </summary>
        public int? IngredientType { get; set; }

        /// <summary>
        /// Image of the ingredient.
        /// </summary>
        public byte[]? Image { get; set; } = default!;
    }
}
