using EPharma.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPharma.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClientesPlanos(Guid id);
    }
}
