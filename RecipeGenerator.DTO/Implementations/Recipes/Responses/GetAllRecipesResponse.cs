using RecipeGenerator.DTO.Interfaces.Responses;

namespace RecipeGenerator.DTO.Implementations.Recipes.Responses
{
    public record GetAllRecipesResponse : IGetAllResponse<IGetAllResponseItem>
    {
        public IEnumerable<IGetAllResponseItem> Items { get; set; } = default!;
    }
}
