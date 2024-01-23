using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Steps
{
    internal class StepFactory : IStepFactory
    {
        public Step Create()
        {
            return new Step()
            {
                Name = string.Empty,
                Index = 0,
                Description = string.Empty,
                Photos = [],
            };
        }
    }
}
