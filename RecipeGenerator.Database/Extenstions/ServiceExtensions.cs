using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Localization.Models;
using RecipeGenerator.Localization.Models.Models;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using RecipeGenerator.Settings;
using System.Globalization;
using System.Linq;

namespace RecipeGenerator.Database.Extenstions
{
    public static class ServiceExtensions
    {
        public static void AddRecipeGeneratorDatabase(this IServiceCollection services, IConfigurationManager configurationManager)
        {
            
            services.AddSqlite<RecipeGeneratorDbContext>($"Data Source=\"{Path.Combine(AppPaths.DataFolder, $"Recipe.{configurationManager.GetSection(DynamicLocalizationOptions.Localization).GetValue<string>("CurrentCulture")}.db")}\"");

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<StepRepository>();
            services.AddTransient<RecipeRepository>();
            services.AddTransient<AppliedIngredientRepository>();
            services.AddTransient<ApplicableIngredientRepository>();

            services.AddTransient<ApplicableIngredientsSeeder>();
        }
    }
}
