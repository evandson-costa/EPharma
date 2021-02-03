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
                .HasColumnType("varchar(100)")
                .HasColumnName("nome");

            builder.Property(p => p.DataFimVigencia)
                .IsRequired()
                .HasColumnName("data_fim_vigencia");

            builder.Property(p => p.DataInicioVigencia)
                .IsRequired()
                .HasColumnName("data_inicio_vigencia"); ;

            builder.Property(p => p.DataCadastro)
                .IsRequired()
                .HasColumnName("data_cadastro");

            builder.Property(p => p.IsPJ)
                .IsRequired()
                .HasColumnName("isPj");

            builder.Property(p => p.Deleted)
                .HasColumnName("deleted");

            builder.Property(p => p.DataAlteracao)
                .HasColumnName("data_alteracao");
        }
    }
}
