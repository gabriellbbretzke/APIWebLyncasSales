using System;
using System.Runtime.InteropServices;
using App_CRUDSalesLyncas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace App_CRUDSalesLyncas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio");

            using var db = new Data.ApplicationContext();
            //InserirDados();
            //InserirDadosEmMassa();
            //ConsultarDados();
            //CadastrarPedido();
            //ConsultaPedidoCarregamentoAdiantado();
            //AtualizarDados();
            //RemoverRegistro();

            Console.WriteLine("Fim");
        }

        private static void InserirDadosEmMassa()
        {
            List<Usuario> usuarios = new List<Usuario>();
            List<Cliente> clientes = new List<Cliente>();
            List<Venda> vendas = new List<Venda>();
            List<ItemVenda> itemVenda = new List<ItemVenda>();

            using var db = new Data.ApplicationContext();

            for (int i = 0; i < 100; i++)
            {
                usuarios.Add(new Usuario
                {
                    Email = $"email{i}@teste.com.br",
                    Senha = "1234567" + i,
                    PerfilAcesso = $"Perfil{i}",
                });

                clientes.Add(new Cliente
                {
                    Nome = $"Nome {i}",
                    Email = $"cliente{i}@teste.com.br",
                    Telefone = "99000" + i,
                    Cpf = "90909098992",
                });

                db.AddRange(usuarios[i], clientes[i]);
            }

            var registros = db.SaveChanges();
            Console.WriteLine($"Total registros: {registros}");
        }
    }
}
