using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.Localization.Services;
using RecipeGenerator.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.Settings
{
 public partial class SettingsView
 {
  [Inject]
  public SettingsViewModel ViewModel { get; set; } = default!;

  [Inject]
  public IStringLocalizer<SettingsView> StringLocalizer { get; set; } = default!;

  [Inject]
  public DynamicLocalizationService DynamicLocalizationService { get; set; } = default!;

  protected override async Task OnInitializedAsync()
  {
   if (ViewModel != null)
   {
    DynamicLocalizationService.PropertyChanged += async (sender, e) => await InvokeAsync(StateHasChanged);
    ViewModel.PropertyChanged += async (sender, e) => await InvokeAsync(StateHasChanged);
    await ViewModel.InitializeAsync();
   }
   var strings = StringLocalizer.GetAllStrings();
  }

  private string currentCulture = default!;
 }
}
