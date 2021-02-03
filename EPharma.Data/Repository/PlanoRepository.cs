using Microsoft.EntityFrameworkCore;
using EPharma.Business.Interfaces;
using EPharma.Business.Models;
using EPharma.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System;

namespace EPharma.Data.Repository
{
    public class PlanoRepository : Repository<Plano>, IPlanoRepository
    {
        public PlanoRepository(EPharmaDbContext context) 
            : base (context)
        {
        }

        public IEnumerable<Plano> ObterPlanos(TipoCliente tipoPessoa = TipoCliente.PessoaFisica)
        {
            if(tipoPessoa.Equals(TipoCliente.PessoaFisica))
            {
                return  Db.Planos.AsNoTracking()
                    .OrderBy(p => p.NomePlano)
                    .Where(c => c.IsPJ == false 
                        && c.Deleted == false 
                        && c.DataFimVigencia >= DateTime.Now
                        && c.ClienteId == null)
                    .ToList();
            }
            else
            {
                return Db.Planos.AsNoTracking()
                   .OrderBy(p => p.NomePlano)
                   .Where(c => c.IsPJ == true 
                        && c.Deleted == false 
                        && c.DataFimVigencia >= DateTime.Now
                        && c. ClienteId == null)
                   .ToList();
            }            
        }

        public IEnumerable<Plano> ObterPlanosIdCliente(Guid idCliente)
        {
            return Db.Planos.AsNoTracking()
                   .OrderBy(p => p.NomePlano)
                   .Where(c=> c.Deleted == false
                        && c.ClienteId == idCliente)
                   .ToList();
        }
    }
}