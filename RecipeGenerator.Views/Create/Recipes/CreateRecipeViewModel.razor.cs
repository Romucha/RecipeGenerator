using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.Create.Recipes
{
 public partial class CreateRecipeViewModel
 {
  [Inject]
  public CreateRecipeViewModel ViewModel { get; set; } = default!;
 }
}
