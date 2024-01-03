using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Explore
{
    public partial class IngredientView
    {
        [Parameter]
        public Ingredient Ingredient { get; set; }

        private string imageURL { get; set; } = "/images/apple.png";

        private string desc { get; set; } = "There could be your ad, but it's just an ingredient.";

        protected override async Task OnInitializedAsync()
        {
            if (Ingredient != null && Ingredient.Image != null)
            {
                if (Ingredient.Image != null)
                {
                    imageURL = string.Format("data:image/svg+xml;base64,{0}", Ingredient.Image);
                }
                if (!string.IsNullOrEmpty(Ingredient.Description))
                {
                    desc = $"{Ingredient.Description.Substring(0,50)}...";
                }
            }
            await base.OnInitializedAsync();
        }
    }
}
