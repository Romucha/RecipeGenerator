namespace RecipeGenerator.DTO.Steps.Responses
{
    public record DeleteStepResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
