﻿using RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses;
using RecipeGenerator.DTO.Implementations.Steps.Responses;
using RecipeGenerator.DTO.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.Recipes.Responses
{
    public record UpdateRecipeResponse : IUpdateResponse
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
        /// Date of last update.
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

        /// <summary>
        /// List of steps.
        /// </summary>
        public List<UpdateStepResponse> Steps { get; set; } = new();

        /// <summary>
        /// List of ingredients.
        /// </summary>
        public List<UpdateAppliedIngredientResponse> Ingredients { get; set; } = new();
    }
}
