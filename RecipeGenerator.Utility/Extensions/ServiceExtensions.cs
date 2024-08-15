using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Utility.Mapping;
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
