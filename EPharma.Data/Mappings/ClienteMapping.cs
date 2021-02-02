using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EPharma.Business.Models;

namespace EPharma.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(80)")
                .HasColumnName("nome");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Telefone)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(p => p.DataCadastro)
                .IsRequired();

            builder.Property(p => p.CpfCnpj)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(p => p.DataNascimento)
                .IsRequired();

            builder.HasMany(p => p.Planos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId);
        }
    }
}