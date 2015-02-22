using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core;
using TaskManagement.Core.DomainEntity;

namespace TaskManagement.Service.GenericService
{
    public interface IService { }

    public interface IEntityService<T> : IService where T : BaseEntity
    {
        Task Create(T entity);
        Task Delete(T entity);
        Task Update(T entity);

        Task<IEnumerable<T>> GetAll();
    }

    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {

        protected IContext _context;
        protected IDbSet<T> _dbSet;

        public EntityService(IContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public virtual async Task Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            //return await _dbSet.AsEnumerable<T>();

            return await _dbSet.ToListAsync<T>();

        }
    }
}
