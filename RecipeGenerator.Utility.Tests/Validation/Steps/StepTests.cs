using FluentValidation;
using RecipeGenerator.Utility.Tests.Validation.Recipes;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Steps
{
    public class StepTests
    {
        [Fact]
        public async Task ValidateNormal()
        {
            var recipe = StepData.Normal;
            var validator = new StepValidator();

            var result = await validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ValidateDefault()
        {
            var recipe = StepData.Default;
            var validator = new StepValidator();

            var result = await validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task ValidateNull()
        {
            var recipe = StepData.Null;
            StepValidator validator = new StepValidator();

            await Assert.ThrowsAsync<ArgumentNullException>(() => validator!.ValidateAndThrowAsync(recipe));
        }

        [Fact]
        public async Task ValidateInvalid()
        {
            var recipe = StepData.Invalid;
            StepValidator validator = new StepValidator();

            var result = await validator!.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
