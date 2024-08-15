using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests
{
    public record GetAllApplicableIngredientsRequest : IGetAllRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; } = default!;
    }
}
