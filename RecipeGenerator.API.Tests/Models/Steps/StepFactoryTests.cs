using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Tests.Models.Steps
{
    public class StepFactoryTests
    {
        [Fact]
        public void Create_Normal()
        {
            //arrange
            IStepFactory stepFactory = new StepFactory();
            var defaultStep = new Step()
            {
                Name = string.Empty,
                Description = string.Empty, 
                Photos = new()
            };
            //act
            var step = stepFactory.Create();
            //assert
            Assert.NotNull(step);
            Assert.Equal(defaultStep.Name, step.Name);
            Assert.Equal(defaultStep.Description, step.Description);
            Assert.Equal(defaultStep.Photos, step.Photos);
        }
    }
}
