using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.Steps.Responses
{
    public record CreateStepResponse : BaseCreateResponse
    {
        /// <summary>
        /// Index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Photos.
        /// </summary>
        public List<byte[]> Photos { get; set; } = [];

        /// <summary>
        /// Recipe identifier.
        /// </summary>
        public int RecipeId { get; set; }
    }
}
