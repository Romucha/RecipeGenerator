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
        [ClassData(typeof(GetAsync_Normal_TestData))]
        public async Task GetAsync_Normal(Step expectedStep)
        {
            //arrange
            await dbContext.AddAsync(expectedStep);
            await dbContext.SaveChangesAsync();

            var id = expectedStep.Id;
            //act
            var actualStep = await repository.GetAsync(id);
            //assert
            Assert.NotNull(actualStep);
            Assert.Equal(expectedStep, actualStep);
        }

        [Theory]
        [ClassData(typeof(GetAsync_ReturnsNull_WhenIdIsInvalid_TestData))]
        public async Task GetAsync_ReturnsNull_WhenIdIsInvalid(Step expectedStep)
        {
            //arrange
            await dbContext.AddAsync(expectedStep);
            await dbContext.SaveChangesAsync();

            var id = new Guid();
            //act
            var actualStep = await repository.GetAsync(id);
            //assert
            Assert.Null(actualStep);
        }
    }
}
