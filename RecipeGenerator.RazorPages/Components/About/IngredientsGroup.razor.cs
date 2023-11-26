﻿using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.RazorPages.ViewModels.About;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Components.About
{
    public partial class IngredientsGroup
    {
        [Parameter]
        public IngredientGroupVM IngredientsGroupVM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private void ToggleVisibility()
        {
            IngredientsGroupVM.IsExpanded = !IngredientsGroupVM.IsExpanded;
        }
    }
}
