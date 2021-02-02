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

        public async Task<IEnumerable<Plano>> ObterPlanos(TipoCliente tipoPessoa = TipoCliente.PessoaFisica)
        {
            if(tipoPessoa.Equals(TipoCliente.PessoaJuridica))
            {
                return await Db.Planos.AsNoTracking()
                    .OrderBy(p => p.NomePlano)
                    .Where(c => c.IsPJ == true)
                    .ToListAsync();
            }

            return await Db.Planos.AsNoTracking()
                   .OrderBy(p => p.NomePlano)
                   .ToListAsync();
        }
    }
}