namespace RecipeGenerator.DTO.Recipes.Responses
{
    public record DeleteRecipeResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
