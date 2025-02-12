using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Utility.Mapping;
using RecipeGenerator.ViewModels.Details.Ingredients;
using RecipeGenerator.ViewModels.Details.Recipes;
using RecipeGenerator.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.ViewModels.Details.Recipes
{
    public partial class DetailsRecipesViewModelTests
    {
        private readonly IServiceProvider provider;

        public DetailsRecipesViewModelTests()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddAutoMapper(cfg => cfg.AddProfile<MapperInitializer>());
            var context = DatabaseData.ProvideDbContext().WithCollections().Result;
            services.AddSingleton<RecipeGeneratorDbContext, RecipeGeneratorDbContext>(c =>
            {
                return context;
            });

            services.AddLogging();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<StepsRepository>();
            services.AddTransient<RecipesRepository>();
            services.AddTransient<AppliedIngredientsRepository>();
            services.AddTransient<ApplicableIngredientsRepository>();
            services.AddTransient<MeasurementsRepository>();
            services.AddTransient<ApplicableIngredientsSeeder>();
            services.AddTransient<IFileSaverService, DummyFileSaverService>();

            services.AddLocalization();

            services.AddTransient<DetailsRecipeViewModel>();

            provider = services.BuildServiceProvider();

        }

        private DetailsRecipeViewModel GetViewModel()
        {
            return provider.GetRequiredService<DetailsRecipeViewModel>();
        }

        private RecipeGeneratorDbContext GetDbContext()
        {
            return provider.GetRequiredService<RecipeGeneratorDbContext>();
        }
    }
}
