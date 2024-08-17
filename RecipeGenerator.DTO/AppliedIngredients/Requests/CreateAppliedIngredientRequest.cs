namespace RecipeGenerator.DTO.AppliedIngredients.Requests
{
    public record CreateAppliedIngredientRequest
    {
        public Guid RecipeId { get; set; }

        public Guid IngredientId { get; set; }
    }
}
