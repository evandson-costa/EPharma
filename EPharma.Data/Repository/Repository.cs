using EPharma.Business.Models;
using Microsoft.EntityFrameworkCore;
using EPharma.Business.Interfaces;
using EPharma.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EPharma.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly EPharmaDbContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(EPharmaDbContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await DbSet
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }             

        public virtual async Task<T> ObterPorId(Guid id)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(c=>c.Id == id);
        }

        public virtual async Task<List<T>> ObterTodos()
        {
            return await DbSet
                .AsNoTracking()
                .Where(c=>c.Deleted == false)
                .ToListAsync();
        }

        public virtual async Task Adicionar(T entity)
        {
            entity.DataCadastro = DateTime.Now;
            entity.Deleted = false;

            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(T entity)
        {
            entity.DataAlteracao = DateTime.Now;

            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(T entity)
        {
            entity.Deleted = true;
            entity.DataAlteracao = DateTime.Now;

            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}