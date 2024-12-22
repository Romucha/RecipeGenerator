using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using RecipeGenerator.Utility.Mapping;
using RecipeGenerator.Utility.Validation;

namespace RecipeGenerator.Utility.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRecipeGeneratorUtility(this IServiceCollection services)
        {
            services.AddMapping();
            services.AddValidation();
        }

        private static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperInitializer));
        }

        private static void AddValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Recipe>, RecipeValidator>();
            services.AddTransient<IValidator<Step>, StepValidator>();
            services.AddTransient<IValidator<ApplicableIngredient>, ApplicableIngredientValidator>();
            services.AddTransient<IValidator<AppliedIngredient>, AppliedIngredientValidator>();
            services.AddTransient<IValidator<Measurement>, MeasurementValidator>();
        }
    }
}
