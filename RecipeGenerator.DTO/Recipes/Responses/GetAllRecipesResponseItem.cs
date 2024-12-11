namespace RecipeGenerator.DTO.Recipes.Responses
{
    public record GetAllRecipesResponseItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
