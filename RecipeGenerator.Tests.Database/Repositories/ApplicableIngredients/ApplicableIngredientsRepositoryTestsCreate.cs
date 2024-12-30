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
            using (var context = await DatabaseData.ProvideDbContext().WithSeeding())
            {
                var repository = GetRepository(context);

                var resposne = await repository.CreateAsync();
                await context.SaveChangesAsync();

                Assert.NotNull(resposne);
                Assert.NotEqual(0, resposne.Id);
                Assert.NotEqual(ApplicableIngredientData.Normal.Id, resposne.Id);
                Assert.Equal(string.Empty, resposne.Name);
                Assert.True(context.ApplicableIngredients.Any(c => c.Id == resposne.Id));
            }
        }
    }
}
