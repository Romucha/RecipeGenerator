using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.Steps.Requests
{
    public record GetStepRequest : IGetRequest
    {
        public Guid Id { get; set; }
    }
}
