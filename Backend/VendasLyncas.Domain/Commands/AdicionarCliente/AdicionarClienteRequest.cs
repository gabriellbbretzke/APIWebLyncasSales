using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Domain.Commands.AdicionarCliente
{
    public class AdicionarClienteRequest : IRequest<CommandResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
    }
}
