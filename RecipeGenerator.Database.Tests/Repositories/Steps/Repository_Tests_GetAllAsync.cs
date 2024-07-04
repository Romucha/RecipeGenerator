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
        [ClassData(typeof(GetAllAsync_Normal_TestData))]
        public async Task GetAllAsync_Normal(IEnumerable<Step> expectedSteps, int pageNumber, int pageSize, int expectedCount)
        {
            //arrange
            await dbContext.AddRangeAsync(expectedSteps);
            await dbContext.SaveChangesAsync();

            //act
            var actualSteps = await repository.GetAllAsync(pageSize, pageNumber);
            //assert
            Assert.NotNull(actualSteps);
            Assert.Equal(expectedCount, actualSteps.Count());
        }
    }
}
