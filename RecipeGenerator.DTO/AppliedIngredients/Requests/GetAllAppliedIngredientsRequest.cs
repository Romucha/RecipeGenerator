namespace RecipeGenerator.DTO.AppliedIngredients.Requests
{
    public record GetAllAppliedIngredientsRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string? Filter { get; set; }
    }
}
