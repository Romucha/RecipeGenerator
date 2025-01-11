using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
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
        public async Task Update_Empty()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);

                var id = StepData.Normal.Id;

                var response = await repository.UpdateAsync(id, null, null, null, null, null);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(StepData.Normal.Id, response.Id);
                Assert.Equal(StepData.Normal.Name, response.Name);
                Assert.Equal(StepData.Normal.Description, response.Description);
                Assert.Equal(StepData.Normal.CreatedAt.Date, response.CreatedAt.Date);
                Assert.Equal(StepData.Normal.UpdatedAt.Date, response.UpdatedAt.Date);
                Assert.Equal(StepData.Normal.RecipeId, response.RecipeId);
                Assert.Equal(StepData.Normal.Photos, response.Photos);
                Assert.Equal(StepData.Normal.Index, response.Index);
            }
        }

        [Fact]
        public async Task Update_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);

                var id = StepData.Normal.Id;
                var name = "Updated";
                var description = "Updated";
                var recipeId = 1;
                var index = 3;
                var photos = new List<byte[]> { };

                var updateTime = ApplicableIngredientData.Normal.UpdatedAt;

                var response = await repository.UpdateAsync(id, name, description, photos, index, recipeId);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(id, response.Id);
                Assert.Equal(name, response.Name);
                Assert.Equal(description, response.Description);
                Assert.Equal(recipeId, response.RecipeId);
                Assert.Equal(photos, response.Photos);
                Assert.Equal(index, response.Index);
                Assert.NotEqual(updateTime, response.UpdatedAt);
            }
        }
    }
}
