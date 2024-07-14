using RecipeGenerator.DTO.Interfaces.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests
{
    public record DeleteApplicableIngredientRequest : IDeleteRequest
    {
        public Guid Id { get; set; }
    }
}
