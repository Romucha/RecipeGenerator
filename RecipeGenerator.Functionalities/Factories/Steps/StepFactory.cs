using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Functionalities.Factories.Steps
{
    internal class StepFactory
    {
        public Step Create()
        {
            return new Step()
            {
                Name = string.Empty,
                Index = 0,
                Description = string.Empty,
                Photos = [],
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
        }
    }
}
