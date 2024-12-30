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
            using (var context = await DatabaseData.ProvideDbContext().WithSeeding())
            {
                var repository = GetRepository(context);
                var expectedId = ApplicableIngredientData.Normal.Id;
                var expectedName = ApplicableIngredientData.Normal.Name;

                var resposne = await repository.DeleteAsync(expectedId);
                await context.SaveChangesAsync();

                Assert.NotNull(resposne);
                Assert.Equal(ApplicableIngredientData.Normal.Id, resposne.Id);
                Assert.Equal(ApplicableIngredientData.Normal.Name, resposne.Name);
                Assert.False(context.ApplicableIngredients.Any(c => c.Id == resposne.Id));
            }
        }

        [Fact]
        public async Task Delete_Default()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSeeding())
            {
                var repository = GetRepository(context);
                var id = 0;

                var resposne = await repository.DeleteAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(resposne);
            }
        }

        [Fact]
        public async Task Delete_NonExistent()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSeeding())
            {
                var repository = GetRepository(context);
                var id = int.MaxValue;

                var resposne = await repository.DeleteAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(resposne);
            }
        }

        [Fact]
        public async Task Delete_Negative()
        {
            using (var context = await DatabaseData.ProvideDbContext().WithSeeding())
            {
                var repository = GetRepository(context);
                var id = -1;

                var resposne = await repository.DeleteAsync(id);
                await context.SaveChangesAsync();

                Assert.Null(resposne);
            }
        }
    }
}
