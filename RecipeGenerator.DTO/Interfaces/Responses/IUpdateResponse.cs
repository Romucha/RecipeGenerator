namespace RecipeGenerator.DTO.Interfaces.Responses
{
    public interface IUpdateResponse
    {
        Guid Id { get; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; }
    }
}
