using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EPharma.Business.Models;

namespace EPharma.Data.Mappings
{
    public class PlanoMapping : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable("Planos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomePlano)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasColumnName("nome");

            builder.Property(p => p.DataFimVigencia)
                .IsRequired();

            builder.Property(p => p.DataInicioVigencia)
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .IsRequired();
        }
    }
}
