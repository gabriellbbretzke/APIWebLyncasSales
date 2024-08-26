using Microsoft.EntityFrameworkCore;
using System.Linq;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.Context.Context;

namespace VendasLyncas.Infra.Data.Repositories
{
    public class RepositoryVenda : RepositoryBase<Venda>, IRepositoryVenda
    { 
        public RepositoryVenda(ApplicationContext context) : base(context)
        {
            DbSet = context.Set<Venda>();
            _context = context;
        }

        public IEnumerable<Venda> ListarComItemVenda()
        {

            return DbSet
                .Include(p => p.Itens)
                .Include(p => p.Cliente)
                .AsEnumerable();
        }

        public Venda ObterComItemVenda(int id)
        {
            return DbSet.Include(p => p.Itens).FirstOrDefault(p => p.Id == id);
        }
    }
}
