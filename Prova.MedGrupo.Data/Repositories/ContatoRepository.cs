using System.Threading.Tasks;
using Prova.MedGrupo.Data.Contexts;
using Prova.MedGrupo.Domain.Entities;
using Prova.MedGrupo.Domain.Interfaces;
using Prova.MedGrupo.Framework.Data.Repositories;

namespace Prova.MedGrupo.Data.Repositories
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(ProvaMedGrupoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> Exists(string nome, int id)
        {
            return id == default ? await Any(x => x.Nome == nome) : await Any(x => x.Nome == nome && x.Id != id);
        }
    }
}