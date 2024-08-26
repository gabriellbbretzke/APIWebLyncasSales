namespace VendasLyncas.Domain.Commands.AdicionarUsuario
{
    public class AdicionarUsuarioResponse
    {
        public int Id { get; }
        public string Mensagem { get; }

        public AdicionarUsuarioResponse(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
