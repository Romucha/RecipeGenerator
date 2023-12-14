using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Steps
{
    public class Step
    {
        [Key]
        public string Id { get; set; }
    }
}
