using RecipeGenerator.DTO.Interfaces.Responses;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses
{
    public record GetAllAppliedIngredientsResponse : IGetAllResponse<IGetAllResponseItem>
    {
        public IEnumerable<IGetAllResponseItem> Items { get; set; } = default!;
    }
}
