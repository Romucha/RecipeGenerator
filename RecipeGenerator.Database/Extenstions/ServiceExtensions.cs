using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;

namespace RecipeGenerator.Database.Extenstions
{
    public static class ServiceExtensions
    {
        public static void AddRecipeGeneratorDatabase(this IServiceCollection services)
        {
            //TO-DO: move generation of db file into a separate method somewhere
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RecipeGenerator");
            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }
            services.AddSqlite<RecipeGeneratorDbContext>($"Data Source=\"{dbPath}/Recipe.db\"");

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepository<Step>, Repository<Step>>();
            services.AddTransient<IRepository<Recipe>, Repository<Recipe>>();
            services.AddTransient<IRepository<AppliedIngredient>, Repository<AppliedIngredient>>();
            services.AddTransient<IRepository<ApplicableIngredient>, Repository<ApplicableIngredient>>();

            services.AddTransient<ApplicableIngredientsSeeder>();
        }
    }
}
