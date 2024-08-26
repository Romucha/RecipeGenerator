using Microsoft.Extensions.Logging;
using RecipeGenerator.Localization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace RecipeGenerator.Localization.Services
{
    public class ConfigurationFileWriterService
    {
        public static string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RecipeGenerator", "settings.json");

        private readonly ILogger<ConfigurationFileWriterService> logger;

        public ConfigurationFileWriterService(ILogger<ConfigurationFileWriterService> logger)
        {
            this.logger = logger;
        }

        public void Write<T>(string parameter, object value)
        {
            try
            {
                var jsonOptions = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                var dirPath = Path.GetDirectoryName(FilePath);
                if (!string.IsNullOrEmpty(dirPath))
                {
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    if (!File.Exists(FilePath))
                    {
                        var obj = Activator.CreateInstance<T>();
                        if (obj != null)
                        {
                            var prop = obj.GetType().GetProperties().FirstOrDefault(p => p.Name == parameter);
                            if (prop != null)
                            {
                                prop.SetValue(obj, value);
                            }
                        }
                        File.WriteAllText(FilePath, JsonSerializer.Serialize(obj, typeof(T), jsonOptions));
                    }
                    else
                    {
                        var jsonString = File.ReadAllText(FilePath);
                        var jsonNode = JsonObject.Parse(jsonString);
                        if (jsonNode != null)
                        {
                            var node = jsonNode[$"{DynamicLocalizationOptions.Localization}"];
                            if (node != null)
                            {
                                node[parameter]= JsonObject.Parse(JsonSerializer.Serialize(value));
                                File.WriteAllText(FilePath, JsonSerializer.Serialize(jsonNode, typeof(JsonObject), jsonOptions));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(Write));
                throw;
            }
        }
    }
}
