using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipeGenerator.Database;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Utility.Mapping;

namespace RecipeGenerator.Tests.Data.Database
{
    public static class DatabaseData
    {
        public static RecipeGeneratorDbContext ProvideDbContext()
        {
            var configuration = new ConfigurationBuilder().Build();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperInitializer>()).CreateMapper();

            DbContextOptions options = new DbContextOptionsBuilder<RecipeGeneratorDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            return new RecipeGeneratorDbContext(configuration, options);
        }

        public static async Task<RecipeGeneratorDbContext> WithSingularItems(this RecipeGeneratorDbContext context)
        {
            await context.Recipes.AddAsync(RecipeData.Normal);
            await context.Steps.AddAsync(StepData.Normal);
            await context.ApplicableIngredients.AddAsync(ApplicableIngredientData.Normal);
            await context.AppliedIngredients.AddAsync(AppliedIngredientData.Normal);
            await context.Measurements.AddAsync(MeasurementData.Normal);
            await context.SaveChangesAsync();

            return context;
        }

        public static async Task<RecipeGeneratorDbContext> WithCollections(this RecipeGeneratorDbContext context)
        {
            await context.ApplicableIngredients.AddRangeAsync(ApplicableIngredientDataCollections.Normal);
            await context.AppliedIngredients.AddRangeAsync(AppliedIngredientDataCollections.Normal);
            await context.SaveChangesAsync();

            return context;
        }
    }
}
