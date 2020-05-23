using System.Threading.Tasks;

namespace Prova.MedGrupo.Framework.Interfaces.Data
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        void RollBack();
        void Untrack<TEntity>(TEntity entit) where TEntity : IEntity;
    }
}