﻿using RecipeGenerator.API.Models.Steps;
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

        public static ICollection<Step> NormalSteps { get; }

        public static ICollection<Step> DefaultSteps { get; }

        public static ICollection<Step> EmptySteps { get; }

        public static ICollection<Step> NullSteps { get; }

        static StepSamples()
        {
            NormalStep = new Step()
            {
                Id = Guid.NewGuid(),
                Name = "Normal Step",
                Description = "Normal Step Description",
                Ingredients = IngredientSamples.NormalIngredients.ToList(),
                Photos =
                [
                    Properties.Resources.apple,
                    Properties.Resources.apple,
                ]
            };

            IStepFactory stepFactory = new StepFactory();
            DefaultStep = stepFactory.DefaultStep();

            EmptyStep = new Step();

            NullStep = null;

            NormalSteps =
            [
                new Step()
                {
                    Id = Guid.NewGuid(),
                    Name = "Normal Step 1 ",
                    Description = "Normal Step Description 1",
                    Ingredients = IngredientSamples.NormalIngredients.ToList(),
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
                    Ingredients = IngredientSamples.NormalIngredients.ToList(),
                    Photos =
                    [
                        Properties.Resources.apple,
                        Properties.Resources.apple,
                    ]
                },
            ];

            DefaultSteps =
            [
                stepFactory.DefaultStep(),
                stepFactory.DefaultStep(),
            ];

            EmptySteps = [];

            NullSteps = null;
        }
    }
}
