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
        public async Task Get_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = StepData.Normal.Id;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(StepData.Normal.Id, response.Id);
                Assert.Equal(StepData.Normal.Name, response.Name);
                Assert.Equal(StepData.Normal.Description, response.Description);
                Assert.Equal(StepData.Normal.CreatedAt.Date, response.CreatedAt.Date);
                Assert.Equal(StepData.Normal.UpdatedAt.Date, response.UpdatedAt.Date);
                Assert.Equal(StepData.Normal.RecipeId, response.RecipeId);
                Assert.Equal(StepData.Normal.Index, response.Index);
                Assert.Equal(StepData.Normal.Photos, response.Photos);
            }
        }

        [Fact]
        public async Task Get_Default()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = 0;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }

        [Fact]
        public async Task Get_NonExistent()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = int.MaxValue;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }

        [Fact]
        public async Task Get_Negative()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = -1;

                var response = await repository.GetAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }
    }
}
