using RecipeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Utility.Tests.Validation.Data
{
    public interface IValidationTestData<T> where T : IRecipeGeneratorEntity
    {
        T Default { get; }

        T? Null { get; }

        T Normal { get; }

        T Invalid { get; }
    }
}
