namespace RecipeGenerator.DTO.AppliedIngredients.Responses
{
    public record DeleteAppliedIngredientResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
