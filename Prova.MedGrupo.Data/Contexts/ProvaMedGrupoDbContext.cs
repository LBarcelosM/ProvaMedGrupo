using Microsoft.EntityFrameworkCore;
using Prova.MedGrupo.Data.EntityConfigurations;
using Prova.MedGrupo.Domain.Entities;

namespace Prova.MedGrupo.Data.Contexts
{
    public class ProvaMedGrupoDbContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        public ProvaMedGrupoDbContext(DbContextOptions<ProvaMedGrupoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoConfiguration());
        }
    }
}