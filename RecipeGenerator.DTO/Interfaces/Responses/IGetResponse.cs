namespace RecipeGenerator.DTO.Interfaces.Responses
{
    public interface IGetResponse
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; }
    }
}
