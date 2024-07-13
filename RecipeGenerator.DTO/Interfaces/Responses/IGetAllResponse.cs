using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Interfaces.Responses
{
    public interface IGetAllResponse<T> where T: IGetAllResponseItem
    {
        IEnumerable<T> Items { get; }
    }
}
