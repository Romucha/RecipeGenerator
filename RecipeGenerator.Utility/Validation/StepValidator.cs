using FluentValidation;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Validation
{
    public class StepValidator : AbstractValidator<Step>
    {
        public StepValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.CreatedAt).NotEmpty();
            RuleFor(x => x.UpdatedAt).NotEmpty();
            RuleFor(x => x.Photos).NotNull();
            RuleForEach(x => x.Photos).NotNull();
            RuleFor(x => x.Index).NotEmpty();
            RuleFor(x => x.RecipeId).NotEmpty();
            RuleFor(x => x.Recipe);
        }
    }
}
