using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Steps
{
    public class StepFactory : IStepFactory
    {
        public Step DefaultStep()
        {
            return new Step()
            {
                Id = Guid.NewGuid(),
                Name = string.Empty,
                Description = string.Empty,
                Ptotos = []
            };
        }
    }
}
