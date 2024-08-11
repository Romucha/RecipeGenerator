using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.Localization.Services;
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

  [Inject]
  public IStringLocalizer<HomeView> StringLocalizer { get; set; } = default!;

  [Inject]
  public DynamicLocalizationService DynamicLocalizationService { get; set; } = default!;

  protected override async Task OnInitializedAsync()
  {
   if (ViewModel != null)
   {
    ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
   }
   if (DynamicLocalizationService != null)
   {
    DynamicLocalizationService.PropertyChanged += (sender, e) => StateHasChanged();
   }
  }
 }
}
