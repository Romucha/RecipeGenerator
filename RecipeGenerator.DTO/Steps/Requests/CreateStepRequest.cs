namespace RecipeGenerator.DTO.Steps.Requests
{
    public record CreateStepRequest
    {
        public Guid RecipeId { get; set; }
    }
}
