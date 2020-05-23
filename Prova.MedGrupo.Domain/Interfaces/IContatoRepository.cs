using System.Threading.Tasks;
using Prova.MedGrupo.Domain.Entities;
using Prova.MedGrupo.Framework.Interfaces.Data;

namespace Prova.MedGrupo.Domain.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<bool> Exists(string nome, int id);
    }
}