using RecipeGenerator.DTO.Base.Requests;

namespace RecipeGenerator.DTO.ApplicableIngredients.Requests
{
    public record UpdateApplicableIngredientRequest : BaseUpdateRequest
    {
        /// <summary>
        /// Link to an internet page about the ingredient.
        /// </summary>
        public Uri? Link { get; set; }

        /// <summary>
        /// Ingredient type.
        /// </summary>
        public int? IngredientType { get; set; }

        /// <summary>
        /// Image of the ingredient.
        /// </summary>
        public byte[]? Image { get; set; }
    }
}
