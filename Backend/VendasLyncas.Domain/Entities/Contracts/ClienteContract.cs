using prmToolkit.NotificationPattern;

namespace VendasLyncas.Domain.Entities.Contracts
{
    public static class ClienteContract
    {
        public static void AdicionarClienteContract(this Cliente cliente)
        {
            new AddNotifications<Cliente>(cliente)
                .IfNullOrInvalidLength(p => p.Nome, 1, 200)
                .IfNullOrInvalidLength(p => p.Email, 1, 300)
                .IfNullOrInvalidLength(p => p.Telefone, 1, 20)
                .IfNullOrInvalidLength(p => p.Cpf, 1, 14)
                .IfNotEmail(p => p.Email)
                .IfNotCpf(p => p.Cpf);
        }

        public static void AtualizarClienteContract(this Cliente cliente)
        {
            new AddNotifications<Cliente>(cliente)
                .IfNullOrInvalidLength(p => p.Nome, 1, 200)
                .IfNullOrInvalidLength(p => p.Email, 1, 300)
                .IfNullOrInvalidLength(p => p.Telefone, 1, 20)
                .IfNullOrInvalidLength(p => p.Cpf, 1, 14)
                .IfNotEmail(p => p.Email)
                .IfNotCpf(p => p.Cpf);
        }
    }
}
