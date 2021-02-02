using EPharma.Business.Interfaces;
using EPharma.Business.Models;
using EPharma.Data.Context;

namespace EPharma.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(EPharmaDbContext context) : base(context)
        {

        }
    }
}
