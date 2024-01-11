using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Tests.Samples
{
    internal static class StepSamples
    {
        public static Step NormalStep { get; }

        public static Step DefaultStep { get; }

        public static Step EmptyStep { get; }

        public static Step NullStep { get; }

        public static List<Step> NormalSteps { get; }

        public static List<Step> DefaultSteps { get; }

        public static List<Step> EmptySteps { get; }

        public static List<Step> NullSteps { get; }

        static StepSamples()
        {
            NormalStep = new Step()
            {
                Id = Guid.NewGuid(),
                Name = "Normal Step",
                Description = "Normal Step Description",
                Photos =
                [
                    Properties.Resources.apple,
                    Properties.Resources.apple,
                ]
            };

            IStepFactory stepFactory = new StepFactory();
            DefaultStep = stepFactory.Create();

            EmptyStep = new Step();

            NullStep = null;

            NormalSteps =
            [
                new Step()
                {
                    Id = Guid.NewGuid(),
                    Name = "Normal Step 1 ",
                    Description = "Normal Step Description 1",
                    Photos =
                    [
                        Properties.Resources.apple,
                        Properties.Resources.apple,
                    ]
                },
                new Step()
                {
                    Id = Guid.NewGuid(),
                    Name = "Normal Step 2",
                    Description = "Normal Step Description 2",
                    Photos =
                    [
                        Properties.Resources.apple,
                        Properties.Resources.apple,
                    ]
                },
            ];

            DefaultSteps =
            [
                stepFactory.Create(),
                stepFactory.Create(),
            ];

            EmptySteps = [];

            NullSteps = null;
        }
    }
}
