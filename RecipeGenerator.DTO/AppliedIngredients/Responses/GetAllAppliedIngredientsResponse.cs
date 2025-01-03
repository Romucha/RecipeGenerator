using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.AppliedIngredients.Responses
{
    public record GetAllAppliedIngredientsResponse : BaseGetAllResponse
    {
        public IEnumerable<GetAllAppliedIngredientsResponseItem> Items { get; set; } = Enumerable.Empty<GetAllAppliedIngredientsResponseItem>();
    }
}
