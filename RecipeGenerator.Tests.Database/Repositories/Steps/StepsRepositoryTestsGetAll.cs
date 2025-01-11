using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.Repositories.Steps
{
    public partial class StepsRepositoryTests
    {
        [Fact]
        public async Task GetAll_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithCollections())
            {
                var repository = GetRepository(context);
                var recipeId = RecipeData.Normal.Id;

                var response = await repository.GetAllAsync(recipeId);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(StepDataCollections.Normal.Count / 3, response.TotalCount);
            }
        }

        [Fact]
        public async Task GetAll_Default()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithCollections())
            {
                var repository = GetRepository(context);
                var recipeId = 0;

                var response = await repository.GetAllAsync(recipeId);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(0, response.TotalCount);
            }
        }

        [Fact]
        public async Task GetAll_NonExistent()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithCollections())
            {
                var repository = GetRepository(context);
                var recipeId = int.MaxValue;

                var response = await repository.GetAllAsync(recipeId);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(0, response.TotalCount);
            }
        }

        [Fact]
        public async Task GetAll_Negative()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithCollections())
            {
                var repository = GetRepository(context);
                var recipeId = -1;

                var response = await repository.GetAllAsync(recipeId);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(0, response.TotalCount);
            }
        }
    }
}
