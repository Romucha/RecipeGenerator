using AutoMapper;
using Microsoft.Extensions.Logging;
using RecipeGenerator.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Repositories
{
    public class MeasurementsRepository
    {
        private readonly ILogger<AppliedIngredientsRepository> logger;
        private readonly RecipeGeneratorDbContext dbContext;
        private readonly IMapper mapper;

        public MeasurementsRepository(ILogger<AppliedIngredientsRepository> logger, RecipeGeneratorDbContext dbContext, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }


    }
}
