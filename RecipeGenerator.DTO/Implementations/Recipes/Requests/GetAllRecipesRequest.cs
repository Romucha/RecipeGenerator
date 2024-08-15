using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.Recipes.Requests
{
    public record GetAllRecipesRequest : IGetAllRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; } = default!;
    }
}
