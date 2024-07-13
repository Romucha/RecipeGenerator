using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeGenerator.Utility.Validation;

namespace RecipeGenerator.Utility.Tests.Validation
{
    public class RecipeGeneratorValidator_Tests
    {
        private readonly ILogger<RecipeGeneratorValidator> logger;

        public RecipeGeneratorValidator_Tests()
        {
            logger = new NullLogger<RecipeGeneratorValidator>();
        }

        [Theory]
        [ClassData(typeof(NormalValidationObjectsData))]
        public async Task ValidateAsync_Normal(ValidationObject? validationObject)
        {
            //arrange
            RecipeGeneratorValidator validator = new(logger);

            //act
            var obj = await validator.ValidateAsync(validationObject)!;

            //assert
            Assert.NotNull(obj);
            Assert.Equal(validationObject, obj);
        }

        [Theory]
        [ClassData(typeof(InvalidValidationObjectsData))]
        public async Task ValidateAsync_ReturnsNull(ValidationObject? validationObject)
        {
            //arrange
            RecipeGeneratorValidator validator = new(logger);

            //act
            var obj = await validator.ValidateAsync(validationObject)!;

            //assert
            Assert.Null(obj);
        }
    }
}