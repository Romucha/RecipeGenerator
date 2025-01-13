using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Extenstions;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.Seeding.ApplicableIngredients;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Localization.Models.Models;
using RecipeGenerator.Settings;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Utility.Mapping;
using RecipeGenerator.ViewModels.CreateOrEdit.Recipes;
using RecipeGenerator.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.ViewModels.CreateOrEdit.Recipes
{
    public partial class CreateOrEditRecipeViewModelTests
    {
        private async Task<CreateOrEditRecipeViewModel> GetViewModel()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddAutoMapper(cfg => cfg.AddProfile<MapperInitializer>());
            var context = await DatabaseData.ProvideDbContext().WithSingularItems();
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

            services.AddTransient<IMediaProviderService, DummyRecipeMediaProviderService>();
            
            services.AddTransient<CreateOrEditRecipeViewModel>();

            var provider = services.BuildServiceProvider();

            return provider.GetRequiredService<CreateOrEditRecipeViewModel>();
        }
    }
}
