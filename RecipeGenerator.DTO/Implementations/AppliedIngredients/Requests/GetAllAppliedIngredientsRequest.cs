using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests
{
    public record GetAllAppliedIngredientsRequest : IGetAllRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; } = default!;
    }
}
