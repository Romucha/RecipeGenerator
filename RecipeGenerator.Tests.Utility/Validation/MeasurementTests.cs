using FluentValidation;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Tests.Data.Models;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Utility.Validation
{
    public class MeasurementTests
    {
        protected AbstractValidator<Measurement> Validator { get; set; }

        public MeasurementTests()
        {
            Validator = new MeasurementValidator();
        }

        [Fact]
        public async Task ValidateNormal()
        {
            var recipe = MeasurementData.Normal;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task ValidateDefault()
        {
            var recipe = MeasurementData.Default;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task ValidateNull()
        {
            var recipe = MeasurementData.Null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => Validator!.ValidateAndThrowAsync(recipe));
        }

        [Fact]
        public async Task ValidateInvalid()
        {
            var recipe = MeasurementData.Invalid;

            var result = await Validator.ValidateAsync(recipe);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
        }
    }
}
