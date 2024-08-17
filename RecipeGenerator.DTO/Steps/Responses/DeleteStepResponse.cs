namespace RecipeGenerator.DTO.Steps.Responses
{
    public record DeleteStepResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
