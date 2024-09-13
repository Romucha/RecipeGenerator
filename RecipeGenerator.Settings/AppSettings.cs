using RecipeGenerator.Localization.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeGenerator.Settings
{
    public class AppSettings
    {
        [JsonPropertyName(DynamicLocalizationOptions.Localization)]
        public DynamicLocalizationOptions Localization { get; set; } = default!;

        public static AppSettings Default => new AppSettings()
        {
            Localization = DynamicLocalizationOptions.DefaultLocalizationOptions
        };
    }
}
