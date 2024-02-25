using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Explore.Ingredients
{
    public partial class IngredientView
    {
        [Parameter]
        public GetIngredientDTO Ingredient { get; set; }

        private string imageURL { get; set; }

        private string desc { get; set; } = "There could be your ad, but it's just an ingredient.";

        protected override async Task OnInitializedAsync()
        {
            if (Ingredient != null)
            {
                if (!string.IsNullOrEmpty(Ingredient.Image))
                {
                    imageURL = Ingredient.Image;
                }
                else
                {
                    imageURL = "/images/apple.png";
                }
                if (!string.IsNullOrEmpty(Ingredient.Description))
                {
                    desc = $"{Ingredient.Description.Substring(0, 50)}...";
                }
            }
            
            await base.OnInitializedAsync();
        }
    }
}
