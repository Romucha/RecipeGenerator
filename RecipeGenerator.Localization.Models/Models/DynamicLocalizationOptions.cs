using RecipeGenerator.Localization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RecipeGenerator.Localization.Models.Models
{
    /// <summary>
    /// Options for configuration of localization.
    /// </summary>
    public class DynamicLocalizationOptions
    {
        /// <summary>
        /// Options name for configuration provider.
        /// </summary>
        public const string Localization = "DynamicLocalization";

        /// <summary>
        /// Current culture.
        /// </summary>
        [Required]
        public string? CurrentCulture { get; set; }

        /// <summary>
        /// List of cultures.
        /// </summary>
        [Required]
        [NotEmpty]
        public IEnumerable<string>? Cultures { get; set; }

        public static DynamicLocalizationOptions DefaultLocalizationOptions => new()
        {
            CurrentCulture = "en",
            Cultures =
            [
                "en",
                "ru",
                "fr"
            ]
        };
    }
}
