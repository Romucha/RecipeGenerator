﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.ApplicableIngredients.Responses
{
    public record UpdateApplicableIngredientResponse
    {
        /// <summary>
        /// Idetifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Date of last update.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Display name.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// Link to an internet page about the ingredient.
        /// </summary>
        public Uri Link { get; set; } = default!;

        /// <summary>
        /// Ingredient type.
        /// </summary>
        public int IngredientType { get; set; }

        /// <summary>
        /// Image of the ingredient.
        /// </summary>
        public string Image { get; set; } = default!;
    }
}
