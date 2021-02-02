using Microsoft.EntityFrameworkCore;
using EPharma.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPharma.Data.Context
{
    public class EPharmaDbContext: DbContext
    {
        public EPharmaDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Plano> Planos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>()
                .HasMany(t=>t.Planos)
                .WithOne(c => c.Cliente);

            // seta tamanho maximo de um item mapeado como varchar 100
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //registra os mappings de uma vez só
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EPharmaDbContext).Assembly);

            // desativa o cascade delete
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
