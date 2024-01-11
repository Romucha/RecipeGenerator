using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Tests.Samples
{
    internal static class IngredientSamples
    {
        public static Ingredient NormalIngredient { get; }

        public static Ingredient DefaultIngredient { get; }

        public static Ingredient EmptyIngredient { get; }

        public static Ingredient NullIngredient { get; }

        public static List<Ingredient> NormalIngredients { get; }

        public static List<Ingredient> DefaultIngredients { get; }

        public static List<Ingredient> EmptyIngredients { get; }

        public static List<Ingredient> NullIngredients { get; }

        static IngredientSamples()
        {
            NormalIngredient = new Ingredient()
            {
                Id = Guid.NewGuid(),
                Name = "Normal Ingredient",
                Description = "Normal Ingredient Description",
                Image = Properties.Resources.apple,
                IngredientType = IngredientType.CerealsAndPulses
            };

            DefaultIngredient = new Ingredient();

            EmptyIngredient = new Ingredient();

            NullIngredient = null;

            NormalIngredients =
            [
                new Ingredient()
                {
                    Id = Guid.NewGuid(),
                    Name = "Normal Ingredient 1",
                    Description = "Normal Ingredient Description 1",
                    Image = Properties.Resources.apple,
                    IngredientType = IngredientType.CerealsAndPulses
                },
                new Ingredient()
                {
                    Id = Guid.NewGuid(),
                    Name = "Normal Ingredient 2",
                    Description = "Normal Ingredient Description 2",
                    Image = Properties.Resources.apple,
                    IngredientType = IngredientType.CerealsAndPulses
                }
            ];

            DefaultIngredients =
            [
                new Ingredient(),
                new Ingredient()
            ];

            EmptyIngredients = [];

            NullIngredients = null;
        }
    }
}
