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
    public class ApplicableIngredientTests
    {
        [Fact]
        public async Task ValidateNormal()
        {
            var recipe = ApplicableIngredientData.Normal;
            var validator = new ApplicableIngredientValidator();

            var result = await validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ValidateDefault()
        {
            var recipe = ApplicableIngredientData.Default;
            var validator = new ApplicableIngredientValidator();

            var result = await validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task ValidateNull()
        {
            var recipe = ApplicableIngredientData.Null;
            var validator = new ApplicableIngredientValidator();

            await Assert.ThrowsAsync<ArgumentNullException>(() => validator!.ValidateAndThrowAsync(recipe));
        }

        [Fact]
        public async Task ValidateInvalid()
        {
            var recipe = ApplicableIngredientData.Invalid;
            var validator = new ApplicableIngredientValidator();

            var result = await validator!.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
