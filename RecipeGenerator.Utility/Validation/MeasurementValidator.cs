using FluentValidation;
using RecipeGenerator.Models.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Validation
{
    public class MeasurementValidator : AbstractValidator<Measurement>
    {
        public MeasurementValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.CreatedAt).NotEmpty();
            RuleFor(x => x.UpdatedAt).NotEmpty();
            RuleFor(x => x.ConversionCoefficient).NotEmpty();
            RuleFor(x => x.IsBase).NotNull();
            RuleFor(x => x.Type).NotNull();
            RuleFor(x => x.Ingredients).NotNull();
            RuleForEach(x => x.Ingredients).NotEmpty();
        }
    }
}
