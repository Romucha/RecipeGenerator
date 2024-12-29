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
            await recipeGeneratorDbContext.ApplicableIngredients.AddAsync(ApplicableIngredientData.Normal);
            await recipeGeneratorDbContext.SaveChangesAsync();

            var resposne = await repository.DeleteAsync(ApplicableIngredientData.Normal.Id);
            await recipeGeneratorDbContext.SaveChangesAsync();

            Assert.NotNull(resposne);
            Assert.Equal(ApplicableIngredientData.Normal.Id, resposne.Id);
            Assert.Equal(ApplicableIngredientData.Normal.Name, resposne.Name);
            Assert.False(recipeGeneratorDbContext.ApplicableIngredients.Any(c => c.Id == resposne.Id));
        }

        [Fact]
        public async Task Delete_Default()
        {
            await recipeGeneratorDbContext.ApplicableIngredients.AddAsync(ApplicableIngredientData.Normal);
            await recipeGeneratorDbContext.SaveChangesAsync();

            var resposne = await repository.DeleteAsync(0);
            await recipeGeneratorDbContext.SaveChangesAsync();

            Assert.Null(resposne);
        }

        [Fact]
        public async Task Delete_NonExistent()
        {
            await recipeGeneratorDbContext.ApplicableIngredients.AddAsync(ApplicableIngredientData.Normal);
            await recipeGeneratorDbContext.SaveChangesAsync();

            var resposne = await repository.DeleteAsync(int.MaxValue);
            await recipeGeneratorDbContext.SaveChangesAsync();

            Assert.Null(resposne);
        }
    }
}
