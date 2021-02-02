using EPharma.Business.Interfaces;
using EPharma.Business.Models;
using EPharma.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPharma.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(EPharmaDbContext context) : base(context)
        {
            
        }            
    }
}
