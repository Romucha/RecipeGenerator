using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.Home
{
 public partial class HomeView
 {
  [Inject]
  public HomeViewModel ViewModel { get; set; } = default!;
 }
}
