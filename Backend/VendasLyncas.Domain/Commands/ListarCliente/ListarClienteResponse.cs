using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Domain.Commands.ListarCliente
{
    public class ListarClienteResponse
    {
        public IEnumerable<Cliente> listadeClientes { get; }

        public ListarClienteResponse(IEnumerable<Cliente> clientes)
        {
            listadeClientes = clientes;
        }
    }
}
