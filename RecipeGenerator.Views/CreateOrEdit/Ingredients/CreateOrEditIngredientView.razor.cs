using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.CreateOrEdit.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Views.Create.Ingredients
{
    public partial class CreateOrEditIngredientView
    {
        [Inject]
        public CreateOrEditIngredientViewModel ViewModel { get; set; } = default!;
    }
}
