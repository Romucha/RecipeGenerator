﻿namespace RecipeGenerator.DTO.Recipes.Responses
{
    public record DeleteRecipeResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
