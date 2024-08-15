using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.Steps.Requests
{
    public record DeleteStepRequest : IDeleteRequest
    {
        public Guid Id { get; set; }
    }
}
