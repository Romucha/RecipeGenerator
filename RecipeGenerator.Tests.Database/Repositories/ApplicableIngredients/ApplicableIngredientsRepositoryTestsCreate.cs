using RecipeGenerator.Tests.Data.Database;
using RecipeGenerator.Tests.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.Repositories.ApplicableIngredients
{
    public partial class ApplicableIngredientsRepositoryTests
    {
        [Fact]
        public async Task Create_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);

                var response = await repository.CreateAsync();
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.NotEqual(0, response.Id);
                Assert.NotEqual(ApplicableIngredientData.Normal.Id, response.Id);
                Assert.Equal(string.Empty, response.Name);
                Assert.True(context.ApplicableIngredients.Any(c => c.Id == response.Id));
            }
        }
    }
}
