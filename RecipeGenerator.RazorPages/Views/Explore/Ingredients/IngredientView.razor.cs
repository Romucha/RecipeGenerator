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
                if (Ingredient.Image != null && Ingredient.Image.Length > 0 && Ingredient.Image.Length < 1000000)
                {
                    var imagesrc = Convert.ToBase64String(Ingredient.Image);
                    imageURL = string.Format("data:image/png;base64,{0}", imagesrc);
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
