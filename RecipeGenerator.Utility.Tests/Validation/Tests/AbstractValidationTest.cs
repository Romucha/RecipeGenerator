using FluentValidation;
using RecipeGenerator.Models;
using RecipeGenerator.Utility.Tests.Validation.Data;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Tests
{
    public abstract class AbstractValidationTest<T> where T: IRecipeGeneratorEntity
    {
        protected abstract IValidationTestData<T> ValidationTestData { get; set; }

        protected abstract AbstractValidator<T> Validator { get; set; }

        [Fact]
        public async Task ValidateNormal()
        {
            var recipe = ValidationTestData.Normal;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ValidateDefault()
        {
            var recipe = ValidationTestData.Default;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task ValidateNull()
        {
            var recipe = ValidationTestData.Null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => Validator!.ValidateAndThrowAsync(recipe));
        }

        [Fact]
        public async Task ValidateInvalid()
        {
            var recipe = ValidationTestData.Invalid;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
