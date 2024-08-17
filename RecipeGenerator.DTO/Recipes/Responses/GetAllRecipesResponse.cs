namespace RecipeGenerator.DTO.Recipes.Responses
{
    public record GetAllRecipesResponse
    {
        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public IEnumerable<GetAllRecipesResponseItem> Items { get; set; } = Enumerable.Empty<GetAllRecipesResponseItem>();
    }
}
