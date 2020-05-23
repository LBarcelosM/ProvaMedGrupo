using System.Threading.Tasks;
using Prova.MedGrupo.Domain.Entities;

namespace Prova.MedGrupo.Domain.Interfaces
{
    public interface IContatoValidations
    {
        Task<bool> Validate(Contato contato);
    }
}