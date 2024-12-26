using FluentValidation;
using RecipeGenerator.Models.Measurements;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Utility.Tests.Validation.Data;
using RecipeGenerator.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Tests
{
    public class MeasurementTests : AbstractValidationTest<Measurement>
    {
        protected override IValidationTestData<Measurement> ValidationTestData { get; set; }
        protected override AbstractValidator<Measurement> Validator { get; set; }

        public MeasurementTests()
        {
            ValidationTestData = new MeasurementData();

            Validator = new MeasurementValidator();
        }
    }
}
