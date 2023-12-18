using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services) 
        {
            services.AddTransient<IngredientFactory, IngredientFactory>();
            services.AddTransient<IngredientGetter, IngredientGetter>();
            services.AddTransient<IRecipeFactory, RecipeFactory>();
            services.AddTransient<IStepFactory, StepFactory>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RecipeGenerator");
            if (!Directory.Exists(dbPath)) {
                Directory.CreateDirectory(dbPath);
            }
            services.AddSqlite<RecipeDbContext>($"Data Source={dbPath}\\Recipe.db");
            services.AddTransient<IngredientRepository, IngredientRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();

            return services;
        }
    }
}
