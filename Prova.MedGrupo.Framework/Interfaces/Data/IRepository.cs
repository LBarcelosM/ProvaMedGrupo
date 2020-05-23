using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prova.MedGrupo.Framework.Interfaces.Data
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null, bool trackChanges = false);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null, bool trackChanges = false);
        Task<bool> Any(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> FindById<T>(T id);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}