using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Domain.Commands.ListarVenda
{
    public class ListarVendaRequest : IRequest<CommandResponse>
    {
    }
}
