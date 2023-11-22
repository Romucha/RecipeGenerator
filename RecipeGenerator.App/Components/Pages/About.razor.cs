﻿using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.App.Components.Pages
{
 public partial class About
 {
  [Inject]
  private IIngredientRepository IngredientRepository { get; set; }

  private IEnumerable<IIngredient> Ingredients { get; set; }

  protected override async Task OnInitializedAsync()
  {
   Ingredients = await IngredientRepository.GetAll();
  }
 }
}
