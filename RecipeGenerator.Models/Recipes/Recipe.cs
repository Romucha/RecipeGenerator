﻿using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Steps;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeGenerator.Models.Recipes
{
    /// <summary>
    /// Recipe.
    /// </summary>
    public class Recipe : IRecipeGeneratorEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; }

        /// <inheritdoc/>
        public DateTime UpdatedAt { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Image.
        /// </summary>
        public byte[] Image { get; set; } = [];

        /// <summary>
        /// Course type.
        /// </summary>
        public Course CourseType { get; set; }

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
        public List<Step> Steps { get; set; } = new();

        /// <summary>
        /// List of ingredients.
        /// </summary>
        public List<AppliedIngredient> Ingredients { get; set; } = new();
    }
}
