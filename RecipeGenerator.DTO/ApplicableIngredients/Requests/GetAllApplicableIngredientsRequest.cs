namespace RecipeGenerator.DTO.ApplicableIngredients.Requests
{
    public record GetAllApplicableIngredientsRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string? Filter { get; set; }
    }
}
