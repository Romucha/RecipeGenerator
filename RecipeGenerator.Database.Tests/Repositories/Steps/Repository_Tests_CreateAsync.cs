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
        [Fact]
        public async Task CreateAsync_Normal()
        {
            //act
            var step = await repository.CreateAsync();
            await dbContext.SaveChangesAsync();
            //assert
            Assert.NotNull(step);
            Assert.NotNull(dbContext.Find<Step>(step.Id));
        }
    }
}
