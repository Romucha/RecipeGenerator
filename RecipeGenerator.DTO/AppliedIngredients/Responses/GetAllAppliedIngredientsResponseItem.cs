namespace RecipeGenerator.DTO.AppliedIngredients.Responses
{
    public record GetAllAppliedIngredientsResponseItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
