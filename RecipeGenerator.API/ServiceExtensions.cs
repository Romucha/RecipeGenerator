using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Models.Ingeridients;
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
            services.AddTransient<IIngredientFactory, IngredientFactory>();
            services.AddTransient<IIngredientGetter, IngredientGetter>();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RecipeGenerator");
            if (!Directory.Exists(dbPath)) {
                Directory.CreateDirectory(dbPath);
            }
            services.AddSqlite<RecipeDbContext>($"Data Source={dbPath}\\Recipe.db");
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();

            return services;
        }
    }
}
