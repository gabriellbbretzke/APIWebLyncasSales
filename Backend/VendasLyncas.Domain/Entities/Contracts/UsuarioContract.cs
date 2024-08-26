using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Entities.Contracts
{
    public static class UsuarioContract
    {
        public static void AdicionarUsuarioContract(this Usuario usuario)
        {
            new AddNotifications<Usuario>(usuario)
                .IfNullOrInvalidLength(p => p.Email, 1, 200)
                .IfNotEmail(p => p.Email)
                .IfNullOrInvalidLength(p => p.Senha, 1, 20)
                .IfNullOrInvalidLength(p => p.PerfilAcesso, 1, 30);
        }

        public static void AtualizarUsuarioContract(this Usuario usuario)
        {
            new AddNotifications<Usuario>(usuario)
                .IfNullOrInvalidLength(p => p.Email, 1, 200)
                .IfNotEmail(p => p.Email)
                .IfNullOrInvalidLength(p => p.Senha, 1, 20)
                .IfNullOrInvalidLength(p => p.PerfilAcesso, 1, 30);
        }
    }
}
