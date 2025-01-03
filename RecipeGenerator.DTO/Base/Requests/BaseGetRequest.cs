using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Base.Requests
{
    public abstract record BaseGetRequest
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }
    }
}
