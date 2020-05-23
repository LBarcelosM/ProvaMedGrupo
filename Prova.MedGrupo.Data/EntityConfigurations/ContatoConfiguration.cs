using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.MedGrupo.Domain.Entities;

namespace Prova.MedGrupo.Data.EntityConfigurations
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.DataNascimento)
                .IsRequired();

            builder.Property(x => x.Sexo)
                .IsRequired()
                .HasColumnType("tinyint");

            builder.ToTable("Contato");
        }
    }
}