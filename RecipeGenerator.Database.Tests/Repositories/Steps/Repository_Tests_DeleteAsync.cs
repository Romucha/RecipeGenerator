using RecipeGenerator.Database.Tests.TestData.Repositories.Steps;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.Repositories.Steps
{
    public partial class Repository_Tests
    {
        [Theory]
        [ClassData(typeof(DeleteAsync_Normal_TestData))]
        public async Task DeleteAsync_Normal(Step expectedStep)
        {
            //arrange
            await dbContext.AddAsync(expectedStep);
            await dbContext.SaveChangesAsync();

            var id = expectedStep.Id;
            //act
            await repository.DeleteAsync(id);
            await dbContext.SaveChangesAsync();
            //assert
            var actualStep = dbContext.Find<Step>(expectedStep.Id);
            Assert.Null(actualStep);
        }

        [Theory]
        [ClassData(typeof(DeleteAsync_DoesNothing_WhenIdIsInvalid_TestData))]
        public async Task DeleteAsync_DoesNothing_WhenIdISInvalid(Step expectedStep)
        {
            //arrange
            await dbContext.AddAsync(expectedStep);
            await dbContext.SaveChangesAsync();

            var id = new Guid();
            //act
            await repository.DeleteAsync(id);
            await dbContext.SaveChangesAsync();
            //assert
            var actualStep = dbContext.Find<Step>(expectedStep.Id);
            Assert.NotNull(actualStep);
        }
    }
}
