﻿using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Tests.Samples
{
    internal static class RecipeSamples
    {
        public static Recipe NormalRecipe { get; }

        public static Recipe DefaultRecipe { get; }

        public static Recipe EmptyRecipe { get; }

        public static Recipe NullRecipe { get; }

        public static List<Recipe> NormalRecipes { get; }

        public static List<Recipe> DefaultRecipes { get; }

        public static List<Recipe> EmptyRecipes { get; }

        public static List<Recipe> NullRecipes { get; }

        static RecipeSamples()
        {
            NormalRecipe = new Recipe()
            {
                Name = "Test Name",
                Description = "Test Description",
                CourseType = Course.Soup,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Image = Properties.Resources.apple,
                Steps = StepSamples.NormalSteps,
            };

            NormalRecipe.Steps.ForEach(c =>
            {
                c.RecipeId = NormalRecipe.Id;
                c.Recipe = NormalRecipe;
            });

            IRecipeFactory recipeFactory = new RecipeFactory();
            DefaultRecipe = recipeFactory.Create().Result;

            EmptyRecipe = new Recipe();

            NullRecipe = null;

            NormalRecipes =
            [
                new Recipe()
                {
                    Name = "Test Name 1",
                    Description = "Test Description 1",
                    CourseType = Course.Soup,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Image = Properties.Resources.apple,
                    Steps = StepSamples.NormalSteps,
                },
                new Recipe()
                {
                    Name = "Test Name 2",
                    Description = "Test Description 2",
                    CourseType = Course.Soup,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Image = Properties.Resources.apple,
                    Steps = StepSamples.NormalSteps,
                }
            ];

            NormalRecipes.ForEach(c =>
            {
                c.Steps.ForEach(x =>
                {
                    x.RecipeId = c.Id;
                    x.Recipe = c;
                });
            });

            DefaultRecipes =
            [
                recipeFactory.Create().Result,
                recipeFactory.Create().Result
            ];

            EmptyRecipes = [];

            NullRecipes = null;
        }
    }
}
