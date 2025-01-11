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
        public async Task Delete_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = StepData.Normal.Id;

                var response = await repository.DeleteAsync(id);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.NotEqual(0, response.Id);
                Assert.Equal(StepData.Normal.Id, response.Id);
                Assert.Equal(StepData.Normal.Name, response.Name);
                Assert.False(context.Steps.Any(c => c.Id == response.Id));
            }
        }

        [Fact]
        public async Task Delete_Invalid()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = 0;

                var response = await repository.DeleteAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }
    }
}
