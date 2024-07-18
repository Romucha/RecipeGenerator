using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.Details.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.Details.Ingredients
{
 public partial class DetailsIngredientView
 {
  [Inject]
  public DetailsIngredientViewModel ViewModel { get; set; } = default!;
 }
}
