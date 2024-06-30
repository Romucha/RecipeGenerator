using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository()
        {
            
        }

        public async Task<CreateResponse> CreateAsync<CreateRequest, CreateResponse>(CreateRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteResponse> DeleteAsync<DeleteRequest, DeleteResponse>(DeleteRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAllResponse> GetAllAsync<GetAllRequest, GetAllResponse>(GetAllRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<GetResponse> GetAsync<GetRequest, GetResponse>(GetRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateResponse> UpdateAsync<UpdateRequest, UpdateResponse>(UpdateRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
