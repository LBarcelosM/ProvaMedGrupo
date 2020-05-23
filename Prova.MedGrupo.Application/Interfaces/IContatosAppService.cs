using System.Collections.Generic;
using System.Threading.Tasks;
using Prova.MedGrupo.Application.ViewModels;

namespace Prova.MedGrupo.Application.Interfaces
{
    public interface IContatosAppService
    {
        Task<IEnumerable<ContatoViewModel>> GetAll();
        Task<ContatoViewModel> GetById(int id);
        Task<int> Create(ContatoViewModel viewModel);
        Task<bool> Update(ContatoViewModel viewModel);
        Task<bool> Delete(int id);
    }
}