using RecipeGenerator.DTO.Interfaces.Responses;

namespace RecipeGenerator.DTO.Implementations.Steps.Responses
{
    public record GetAllStepResponse : IGetAllResponseItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
