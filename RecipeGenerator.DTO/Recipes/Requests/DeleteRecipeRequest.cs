namespace RecipeGenerator.DTO.Recipes.Requests
{
    public record DeleteRecipeRequest
    {
        public Guid Id { get; set; }
    }
}
