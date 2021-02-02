using Microsoft.EntityFrameworkCore;
using EPharma.Business.Interfaces;
using EPharma.Business.Models;
using EPharma.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPharma.Data.Repository
{
    public class PlanoRepository : Repository<Plano>, IPlanoRepository
    {
        public PlanoRepository(EPharmaDbContext context) 
            : base (context)
        {
        }

        /// <summary>
        /// Retorna um plano e o dado do cliente
        /// </summary>
        /// <param name="planoId">Id do plano</param>
        /// <returns>Plano</returns>
        public async Task<Plano> ObterPlanoCliente(Guid planoId)
        {
            return await Db.Planos
                .AsNoTracking()
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(p => p.Id == planoId);                
        }

        /// <summary>
        /// retorna lista de planos por cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Plano>> ObterPlanosPorCliente(Guid clienteId)
        {
            return await Buscar(c => c.ClienteId == clienteId);
        }

        /// <summary>
        /// retorna planos e dados dos clientes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Plano>> ObterPlanosClientes()
        {
            return await Db.Planos
                .AsNoTracking()
                .Include(p => p.Cliente)
                .OrderBy(p => p.NomePlano)
                .ToListAsync();
        }
    }
}