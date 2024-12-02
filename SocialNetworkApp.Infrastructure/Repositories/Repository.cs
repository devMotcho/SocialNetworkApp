using Microsoft.EntityFrameworkCore;
using SocialNetworkApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkApp.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly SocialNetworkAppDbContext _dbContext;
        public Repository(SocialNetworkAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Add(entity);
        }
        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public virtual Task<List<T>> FindAllAsync()
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public virtual Task<T> FindByIdAsync(int id)
        {
            return _dbContext.Set<T>().SingleAsync(x => x.Id == id);
        }

        public abstract Task<T> FindOrCreateAsync(T entity);

    }
}
