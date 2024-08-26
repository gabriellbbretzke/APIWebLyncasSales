using VendasLyncas.Domain.Entities.Contracts;

namespace VendasLyncas.Domain.Entities
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Cpf { get; private set; }
        public bool FlagAtivo { get; private set; }

        //Contrutor para o EF
        protected Cliente() { }

        public Cliente(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            FlagAtivo = true;

            this.AdicionarClienteContract();
        }

        public void Atualizar(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone= telefone;
            Cpf = cpf;

            this.AtualizarClienteContract();
        }

        public void Inativar()
        {
            FlagAtivo = false;
        }
    }
}
