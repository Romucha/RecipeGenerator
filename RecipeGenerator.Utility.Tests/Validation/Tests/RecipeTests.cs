using FluentValidation;
using RecipeGenerator.Utility.Tests.Validation.Data;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Tests
{
    public class RecipeTests
    {
        [Fact]
        public async Task ValidateNormal()
        {
            var recipe = RecipeData.Normal;
            var validator = new RecipeValidator();

            var result = await validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ValidateDefault()
        {
            var recipe = RecipeData.Default;
            var validator = new RecipeValidator();

            var result = await validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task ValidateNull()
        {
            var recipe = RecipeData.Null;
            RecipeValidator validator = new RecipeValidator();

            await Assert.ThrowsAsync<ArgumentNullException>(() => validator!.ValidateAndThrowAsync(recipe));
        }

        [Fact]
        public async Task ValidateInvalid()
        {
            var recipe = RecipeData.Invalid;
            RecipeValidator validator = new RecipeValidator();

            var result = await validator!.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
