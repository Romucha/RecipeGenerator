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
    public class AppliedIngredientTests
    {
        [Fact]
        public async Task ValidateNormal()
        {
            var recipe = AppliedIngredientData.Normal;
            var validator = new AppliedIngredientValidator();

            var result = await validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ValidateDefault()
        {
            var recipe = AppliedIngredientData.Default;
            var validator = new AppliedIngredientValidator();

            var result = await validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task ValidateNull()
        {
            var recipe = AppliedIngredientData.Null;
            var validator = new AppliedIngredientValidator();

            await Assert.ThrowsAsync<ArgumentNullException>(() => validator!.ValidateAndThrowAsync(recipe));
        }

        [Fact]
        public async Task ValidateInvalid()
        {
            var recipe = AppliedIngredientData.Invalid;
            var validator = new AppliedIngredientValidator();

            var result = await validator!.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
