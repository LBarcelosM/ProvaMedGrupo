using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prova.MedGrupo.Data.Contexts;
using Prova.MedGrupo.Framework.Interfaces.Data;

namespace Prova.MedGrupo.Data.UnitOfWork
{
    public class ProvaMedGrupoUnitOfWork : IUnitOfWork
    {
        private readonly ProvaMedGrupoDbContext _context;
        public ProvaMedGrupoUnitOfWork(ProvaMedGrupoDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void RollBack()
        {
            var changedEntries = _context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
            if ((changedEntries?.Any()).GetValueOrDefault())
            {
                foreach (var entry in changedEntries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Unchanged;
                            break;
                    }
                }
            }
        }

        public void Untrack<TEntity>(TEntity entity) where TEntity : IEntity
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}