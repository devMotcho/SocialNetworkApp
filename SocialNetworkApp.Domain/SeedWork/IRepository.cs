using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetworkApp.Domain.SeedWork
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T entity);
        void Update(T entity);
        Task<T> FindOrCreateAsync(T entity);
        void Delete(T entity);
        Task<T> FindByIdAsync(int id);
        Task<List<T>> FindAllAsync();
    }
}
