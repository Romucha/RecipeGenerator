namespace RecipeGenerator.DTO.Recipes.Requests
{
    public record GetAllRecipesRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string? Filter { get; set; }
    }
}
