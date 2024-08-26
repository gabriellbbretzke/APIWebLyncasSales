using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Domain.Commands.ListarUsuario
{
    public class ListarUsuarioResponse
    {
        public IEnumerable<Usuario> listadeUsuarios { get; }

        public ListarUsuarioResponse(IEnumerable<Usuario> usuarios)
        {
            listadeUsuarios = usuarios;
        }
    }
}
