using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.RazorPages.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Home.Tables
{
    public partial class RecipeTableItem
    {
        [Parameter]
        public GetRecipeDTO Recipe { get; set; }

        [Parameter]
        public HomeVM HomeVM { get; set; }

        private async Task DeleteRecipe()
        {
            DeleteRecipeDTO deleteRecipeDTO = new DeleteRecipeDTO
            {
                Id = Recipe.Id
            };
            await HomeVM.DeleteRecipeCommand.ExecuteAsync(deleteRecipeDTO);

            StateHasChanged();
        }
    }
}
