using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Resources.Models;
using RecipeGenerator.Resources.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Resources.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds resources for recipe generator localization.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">Configuration provider.</param>
        public static void AddRecipeGeneratorResources(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DynamicLocalizationService>();
            services.Configure<DynamicLocalizationOptions>(options => 
            { 
                configuration.Bind(DynamicLocalizationOptions.Localization, options);
            });
        }
    }
}
