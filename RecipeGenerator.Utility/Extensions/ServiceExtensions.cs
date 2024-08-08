using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RecipeGenerator.Utility.Validation;

namespace RecipeGenerator.Utility.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRecipeGeneratorUtility(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperInitializer));
            services.AddTransient<RecipeGeneratorValidator>();
        }
    }
}
