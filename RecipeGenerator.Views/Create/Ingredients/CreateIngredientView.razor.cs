using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.Create.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.Create.Ingredients
{
 public partial class CreateIngredientView
 {
  [Inject]
  public CreateIngredientViewModel ViewModel { get; set; } = default!;
 }
}
