using Microsoft.AspNetCore.Components;
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
 }
}
