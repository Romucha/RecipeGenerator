using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.ViewModels.Create.Ingredients;
using RecipeGenerator.ViewModels.Display.Collections.Ingredients;
using RecipeGenerator.ViewModels.Display.Entities.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRecipeGeneratorViewModels(this IServiceCollection services)
        {
            addRecipes(services);
        }

        private static void addRecipes(IServiceCollection services)
        {
            services.AddTransient<CreateRecipeViewModel>();
            services.AddTransient<GetAllRecipesViewModel>();
            services.AddTransient<ViewOrEditRecipeViewModel>();
        }
    }
}
