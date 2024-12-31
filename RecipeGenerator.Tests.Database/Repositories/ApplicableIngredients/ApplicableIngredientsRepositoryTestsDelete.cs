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
        public async Task Delete_Normal()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var expectedId = ApplicableIngredientData.Normal.Id;
                var expectedName = ApplicableIngredientData.Normal.Name;

                var response = await repository.DeleteAsync(expectedId);
                await context.SaveChangesAsync();

                Assert.NotNull(response);
                Assert.Equal(ApplicableIngredientData.Normal.Id, response.Id);
                Assert.Equal(ApplicableIngredientData.Normal.Name, response.Name);
                Assert.False(context.ApplicableIngredients.Any(c => c.Id == response.Id));
            }
        }

        [Fact]
        public async Task Delete_Default()
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

        [Fact]
        public async Task Delete_NonExistent()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = int.MaxValue;

                var response = await repository.DeleteAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }

        [Fact]
        public async Task Delete_Negative()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSingularItems())
            {
                var repository = GetRepository(context);
                var id = -1;

                var response = await repository.DeleteAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(response);
            }
        }
    }
}
