using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EPharma.Business.Models;

namespace EPharma.Business.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task Adicionar(T entity);

        Task<T> ObterPorId(Guid id);

        Task<List<T>> ObterTodos();

        Task Atualizar(T obj);

        Task Remover(T entity);

        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);

        Task<int> SaveChanges();
    }
}
