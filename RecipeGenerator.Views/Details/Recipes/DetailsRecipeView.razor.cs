﻿using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.Details.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.Details.Recipes
{
    public partial class DetailsRecipeView
    {
        [Inject]
        public DetailsRecipeViewModel ViewModel { get; set; } = default!;

        [Parameter]
        public Guid Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                await ViewModel.GetRecipeAsync(Id);
            }
        }
    }
}
