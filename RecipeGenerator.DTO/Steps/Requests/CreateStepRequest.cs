using RecipeGenerator.DTO.Base.Requests;

namespace RecipeGenerator.DTO.Steps.Requests
{
    public record CreateStepRequest : BaseCreateRequest
    {
        public int RecipeId { get; set; }
    }
}
