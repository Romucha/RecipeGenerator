using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Localization.Factories;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.Resources.Models;
using RecipeGenerator.Resources.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Localization.Extensions
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
            services.AddTransient<DynamicLocalizationServiceFactory>();
            services.Configure<DynamicLocalizationOptions>(options => 
            { 
                configuration.Bind(DynamicLocalizationOptions.Localization, options);
            });
            services.AddSingleton<DynamicLocalizationServiceProvider>();
        }
    }
}
