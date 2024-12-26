using FluentValidation;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Utility.Tests.Validation.Data;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Tests
{
    public class RecipeTests : AbstractValidationTest<Recipe>
    {
        protected override IValidationTestData<Recipe> ValidationTestData { get; set; }
        protected override AbstractValidator<Recipe> Validator { get; set; }

        public RecipeTests()
        {
            ValidationTestData = new RecipeData();

            Validator = new RecipeValidator();
        }
    }
}
