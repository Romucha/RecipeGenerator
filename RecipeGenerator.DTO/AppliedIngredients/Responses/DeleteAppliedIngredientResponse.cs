namespace RecipeGenerator.DTO.AppliedIngredients.Responses
{
    public record DeleteAppliedIngredientResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
