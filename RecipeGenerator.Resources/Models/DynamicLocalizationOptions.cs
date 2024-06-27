using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Resources.Models
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
        public string? CurrentCulture { get; set; }

        /// <summary>
        /// List of cultures.
        /// </summary>
        public IEnumerable<string>? Cultures { get; set; }

        public static DynamicLocalizationOptions DefaultLocalizationOptions => new()
        {
            CurrentCulture = "en",
            Cultures =
            [
                "en",
                "ru"
            ]
        };
    }
}
