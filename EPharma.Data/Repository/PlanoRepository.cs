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
               
    }
}