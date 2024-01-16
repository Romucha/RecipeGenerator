using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models
{
    internal interface IParametersFromSource<T> where T : class
    {
        void CopyFromSource(T source);
    }
}
