using RecipeGenerator.DTO.Base.Requests;

namespace RecipeGenerator.DTO.Steps.Requests
{
    public record UpdateStepRequest : BaseUpdateRequest
    {
        /// <summary>
        /// Counter.
        /// </summary>
        public int? Index { get; set; }

        /// <summary>
        /// List of photos.
        /// </summary>
        public List<byte[]>? Photos { get; set; }

        /// <summary>
        /// Identifier of the parent recipe.
        /// </summary>
        public int RecipeId { get; set; }
    }
}
