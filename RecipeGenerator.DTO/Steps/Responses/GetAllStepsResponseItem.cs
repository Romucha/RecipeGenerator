﻿namespace RecipeGenerator.DTO.Steps.Responses
{
    public record GetAllStepsResponseItem
    {
        public int Id { get; set; }

        public int Index { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
