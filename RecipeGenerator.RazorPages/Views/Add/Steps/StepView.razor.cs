using BlazorContextMenu;
using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.DTO.Steps;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Add.Steps
{
    public partial class StepView
    {
        [Parameter]
        public IEnumerable<GetIngredientDTO> SelectedIngredients { get; set; }

        [Parameter]
        public CreateStepDTO Step { get; set; }

        private string menuId => Guid.NewGuid().ToString();

        private void AddIngredient(GetIngredientDTO ingredient)
        {
            string.Concat(Step.Description, $" {ingredient.Name.ToLower()}");
        }
    }
}
