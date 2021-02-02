using EPharma.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPharma.Business.Interfaces
{
    public interface IPlanoRepository : IRepository<Plano>
    {
        // Retorna lista de planos por clientes
        Task<IEnumerable<Plano>> ObterPlanosPorCliente(Guid clienteId);

        // Retorna lista de planos com informação do cliente
        Task<IEnumerable<Plano>> ObterPlanosClientes();

        //Retorna um plano e o dado do cliente
        Task<Plano> ObterPlanoCliente(Guid planoId);
    }
}
