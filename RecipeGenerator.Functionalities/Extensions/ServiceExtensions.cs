using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Functionalities.Factories.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Functionalities.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRecipeGeneratorFunctionality(this IServiceCollection services)
        {
            services.AddTransient<ApplicableIngredientFactory>();
        }
    }
}
