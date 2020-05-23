using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prova.MedGrupo.Framework.Interfaces.Data;

namespace Prova.MedGrupo.Framework.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DbContext _context;

        public Repository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null, bool trackChanges = false)
        {
            return await Query(predicate, trackChanges).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null, bool trackChanges = false)
        {
            return await Query(predicate, trackChanges).ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Query(predicate).AnyAsync();
        }

        public async Task<TEntity> FindById<T>(T id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        private IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null, bool trackChanges = false)
        {
            var query = predicate != null ? _context.Set<TEntity>().Where(predicate) : _context.Set<TEntity>();
            return trackChanges ? query : query.AsNoTracking();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}