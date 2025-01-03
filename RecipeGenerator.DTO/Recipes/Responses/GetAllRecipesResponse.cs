using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.Recipes.Responses
{
    public record GetAllRecipesResponse : BaseGetAllResponse
    {
        public IEnumerable<GetAllRecipesResponseItem> Items { get; set; } = Enumerable.Empty<GetAllRecipesResponseItem>();
    }
}
