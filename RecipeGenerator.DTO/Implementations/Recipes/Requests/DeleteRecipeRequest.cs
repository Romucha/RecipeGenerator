namespace RecipeGenerator.DTO.Implementations.Recipes.Requests
{
    public record DeleteRecipeRequest
    {
        public Guid Id { get; set; }
    }
}
