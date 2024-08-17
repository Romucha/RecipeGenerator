using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.ApplicableIngredients.Requests
{
    public record GetAllApplicableIngredientsRequest : IGetAllRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; } = default!;
    }
}
