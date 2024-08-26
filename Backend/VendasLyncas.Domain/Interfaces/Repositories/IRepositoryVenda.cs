using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Domain.Interfaces.Repositories
{
    public interface IRepositoryVenda : IRepositoryBase<Venda>
    {
        IEnumerable<Venda> ListarComItemVenda();
        Venda ObterComItemVenda(int id);
    }
}
