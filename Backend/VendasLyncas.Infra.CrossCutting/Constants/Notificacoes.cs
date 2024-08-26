using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Infra.CrossCutting.Constants
{
    public struct Notificacoes
    {
        public const string CLIENTE_MODULO = "Cliente";
        public const string VENDA_MODULO = "Venda";
        public const string USUARIO_MODULO = "Usuario";

        public const string REQUEST_INVALIDO = "Request Inválido";

        public const string CLIENTE_NAO_LOCALIZADO = "Cliente não localizado.";
        public const string CLIENTE_REGISTRADO = "Cliente Registrado com Sucesso.";
        public const string CLIENTE_ATUALIZADO = "Cliente Atualizado com Sucesso";
        public const string CLIENTE_REMOVIDO = "Cliente Removido com Sucesso";

        public const string VENDA_NAO_LOCALIZADA = "Venda não localizada.";
        public const string VENDA_REGISTRADA = "Venda Registrada com Sucesso";
        public const string VENDA_ATUALIZADA = "Venda Atualizada com Sucesso";
        public const string VENDA_REMOVIDO = "Venda Removida com Sucesso";

        public const string USUARIO_NAO_LOCALIZADO = "Usuario não localizado.";
        public const string USUARIO_REGISTRADO = "Usuario Registrado com Sucesso.";
        public const string USUARIO_ATUALIZADO = "Usuario Atualizado com Sucesso";
        public const string USUARIO_REMOVIDO = "Usuario Removido com Sucesso";

    }
}
