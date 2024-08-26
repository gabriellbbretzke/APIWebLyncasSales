using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Domain.Commands.RemoverCliente
{
    public class RemoverClienteRequest : IRequest<CommandResponse>
    {
        public int Id { get; set; }
    }
}
