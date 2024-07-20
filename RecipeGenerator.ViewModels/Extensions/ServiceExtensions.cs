using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.ViewModels.About;
using RecipeGenerator.ViewModels.Create.Ingredients;
using RecipeGenerator.ViewModels.Details.Ingredients;
using RecipeGenerator.ViewModels.Details.Recipes;
using RecipeGenerator.ViewModels.Home;
using RecipeGenerator.ViewModels.List.Ingredients;
using RecipeGenerator.ViewModels.List.Recipes;
using RecipeGenerator.ViewModels.Settings;
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
            about(services);
            create(services);
            details(services);
            home(services);
            list(services);
            settings(services);
        }

        private static void about(IServiceCollection services)
        {
            services.AddTransient<AboutViewModel>();
        }

        private static void create(IServiceCollection services)
        {
            services.AddTransient<CreateIngredientViewModel>();

            services.AddTransient<CreateRecipeViewModel>();
        }

        private static void details(IServiceCollection services)
        {
            services.AddTransient<DetailsIngredientViewModel>();
            services.AddTransient<DetailsRecipeViewModel>();
        }

        private static void home(IServiceCollection services)
        {
            services.AddTransient<HomeViewModel>();
        }

        private static void list(IServiceCollection services)
        {
            services.AddTransient<ListIngredientsViewModel>();
            services.AddTransient<ListRecipesViewModel>();
        }

        private static void settings(IServiceCollection services)
        {
            services.AddTransient<SettingsViewModel>();
        }
    }
}
