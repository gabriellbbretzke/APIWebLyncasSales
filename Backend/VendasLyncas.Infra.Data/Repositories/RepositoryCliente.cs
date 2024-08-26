using Microsoft.EntityFrameworkCore;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.Context.Context;
using VendasLyncas.Infra.Data.Repositories;

namespace VendasLyncas.Infra.Context.Repositories
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(ApplicationContext context) : base(context)
        {
        }
    }
}
