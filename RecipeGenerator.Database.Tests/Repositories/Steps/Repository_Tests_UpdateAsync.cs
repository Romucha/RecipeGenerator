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
        [ClassData(typeof(UpdateAsync_Normal_TestData))]
        public async Task UpdateAsync_Normal(Step expectedStep, string expectedDescription)
        {
            //arrange
            await dbContext.AddAsync(expectedStep);
            await dbContext.SaveChangesAsync();

            var id = expectedStep.Id;
            var actualStep = await repository.GetAsync(id);
            //act
            actualStep!.Description = expectedDescription;
            await repository.UpdateAsync(actualStep);
            await dbContext.SaveChangesAsync();
            //assert
            Assert.NotNull(actualStep);
            Assert.Equal(expectedStep, actualStep);
            Assert.Equal(expectedDescription, actualStep.Description);
        }
    }
}
