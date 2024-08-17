namespace RecipeGenerator.DTO.AppliedIngredients.Responses
{
    public record GetAllAppliedIngredientsResponse
    {
        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<GetAllAppliedIngredientsResponseItem> Items { get; set; } = Enumerable.Empty<GetAllAppliedIngredientsResponseItem>();
    }
}
