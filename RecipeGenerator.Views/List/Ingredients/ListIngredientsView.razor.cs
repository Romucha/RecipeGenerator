using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.List.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.List.Ingredients
{
 public partial class ListIngredientsView
 {
  [Inject]
  public ListIngredientsViewModel ViewModel { get; set; } = default!;
 }
}
