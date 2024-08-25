using Microsoft.Extensions.Options;
using RecipeGenerator.Localization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeGenerator.Settings
{
    public class DefaultAppSettings
    {
        [JsonPropertyName(DynamicLocalizationOptions.Localization)]
        public DynamicLocalizationOptions DynamicLocalizationOptions { get; set; } = DynamicLocalizationOptions.DefaultLocalizationOptions;

        private DefaultAppSettings() { }

        private static DefaultAppSettings? instance = null;

        public static DefaultAppSettings? Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DefaultAppSettings();
                }

                return instance;
            }
        }
    }
}
