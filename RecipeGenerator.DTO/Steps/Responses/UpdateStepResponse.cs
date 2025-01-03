using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.Steps.Responses
{
    public record UpdateStepResponse : BaseUpdateResponse
    {
        /// <summary>
        /// Counter.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// List of photos.
        /// </summary>
        public List<byte[]> Photos { get; set; } = new();
    }
}
