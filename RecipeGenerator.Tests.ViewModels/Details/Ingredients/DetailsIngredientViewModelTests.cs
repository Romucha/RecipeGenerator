using Microsoft.Extensions.DependencyInjection;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.ViewModels.CreateOrEdit.Recipes;
using RecipeGenerator.Utility.Mapping;
using RecipeGenerator.ViewModels.CreateOrEdit.Recipes;
using RecipeGenerator.ViewModels.Details.Ingredients;
using RecipeGenerator.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.ViewModels.Details.Ingredients
{
    public partial class DetailsIngredientViewModelTests
    {
        private readonly IServiceProvider provider;

        public DetailsIngredientViewModelTests()
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

            services.AddLocalization();

            services.AddTransient<DetailsIngredientViewModel>();

            provider = services.BuildServiceProvider();

        }

        private DetailsIngredientViewModel GetViewModel()
        {
            return provider.GetRequiredService<DetailsIngredientViewModel>();
        }

        private RecipeGeneratorDbContext GetDbContext()
        {
            return provider.GetRequiredService<RecipeGeneratorDbContext>();
        }
    }
}
