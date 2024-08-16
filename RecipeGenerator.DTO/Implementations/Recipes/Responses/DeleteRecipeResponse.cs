namespace RecipeGenerator.DTO.Implementations.Recipes.Responses
{
    public record DeleteRecipeRespons
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
