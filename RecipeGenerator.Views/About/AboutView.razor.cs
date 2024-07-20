using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.About
{
 public partial class AboutView
 {
  [Inject]
  public AboutViewModel ViewModel { get; set; } = default!;
 }
}
