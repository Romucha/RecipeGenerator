namespace RecipeGenerator.DTO.ApplicableIngredients.Responses
{
    public record GetAllApplicableIngredientsResponse
    {
        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public IEnumerable<GetAllApplicableIngredientsResponseItem> Items { get; set; } = Enumerable.Empty<GetAllApplicableIngredientsResponseItem>();
    }
}
