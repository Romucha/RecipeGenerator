using RecipeGenerator.API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.App.Pages
{
    public partial class About
    {
        private IIngredientRepository IngredientRepository { get; set; }
    }
}
