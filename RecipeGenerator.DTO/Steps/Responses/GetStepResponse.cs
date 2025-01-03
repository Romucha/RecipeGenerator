using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.Steps.Responses
{
    public record GetStepResponse : BaseGetResponse
    {
        /// <summary>
        /// Image.
        /// </summary>
        public List<byte[]> Photos { get; set; } = [];

        /// <summary>
        /// Index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Identifier of a parent recipe.
        /// </summary>
        public int RecipeId { get; set; }
    }
}
