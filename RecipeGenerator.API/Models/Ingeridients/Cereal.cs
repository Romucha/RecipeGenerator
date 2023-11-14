using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    public class Cereal : IIngredient
    {
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public Uri Link
        {
            get; set;
        }
    }
}
