using EPharma.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPharma.Business.Interfaces
{
    public interface IPlanoRepository : IRepository<Plano>
    {
        Task<IEnumerable<Plano>> ObterPlanos(TipoCliente tipoPessoa);
    }
}
