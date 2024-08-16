namespace RecipeGenerator.DTO.Implementations.Steps.Requests
{
    public record CreateStepRequest
    {
        public Guid RecipeId { get; set; }
    }
}
