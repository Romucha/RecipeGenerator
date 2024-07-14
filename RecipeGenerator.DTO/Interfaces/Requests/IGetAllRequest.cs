using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Interfaces.Requests
{
    public interface IGetAllRequest
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }

        string Filter { get; set; }
    }
}
