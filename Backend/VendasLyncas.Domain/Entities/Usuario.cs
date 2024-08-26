using VendasLyncas.Domain.Entities.Contracts;

namespace VendasLyncas.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string PerfilAcesso { get; private set; }

        //Construtor para EF
        protected Usuario() { }

        public Usuario(string email, string senha, string perfilAcesso)
        {
            Email = email;
            Senha = senha;
            PerfilAcesso = perfilAcesso;

            this.AdicionarUsuarioContract();
        }

        public void Atualizar(string email, string senha, string perfilAcesso)
        {
            Email = email;
            Senha = senha;
            PerfilAcesso = perfilAcesso;

            this.AtualizarUsuarioContract();
        }
    }
}
