using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Domain.Commands.ObterCliente
{
    public class ObterClienteResponse
    {
        public int Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string Telefone { get; }
        public string Cpf { get; }
        public bool FlagAtivo { get; }

        public ObterClienteResponse(int id, string nome, string email, string telefone, string cpf, bool clienteAtivo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            FlagAtivo = clienteAtivo;
        }
    }
}
