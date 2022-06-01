using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Funcoes
{
    internal class TelaCliente
    {
        public static void Chamar()
        {
            while (true)
            {
                Console.WriteLine("============ Cadastro de Clientes ============");

                string mensagem = "\nOlá, usuário, bem vindo ao programa\n" +
                "\n  Utilizando programação funcional" +
                "\n\n" +
                "\n     Digite uma das opções abaixo:" +
                "\n         0 - Sair do cadastro" +
                "\n         1 - Para cadastrar clientes" +
                "\n         2 - Listar Clientes";

                Console.WriteLine(mensagem);

                int valor = int.Parse(Console.ReadLine());

                if(valor == 0)
                {
                    break;
                }
                else if (valor == 1)
                {
                    var cliente = new Cliente();
                    Console.WriteLine("Digite o nome:");
                    cliente.Nome = Console.ReadLine();
                    Console.WriteLine("Digite o telefone:");
                    cliente.Telefone = Console.ReadLine();
                    Console.WriteLine("Digite o CPF:");
                    cliente.CPF = Console.ReadLine();
                    Console.WriteLine("Concluído!");
                    cliente.Gravar();
                }
                else if (valor == 2)
                {
                    var clientes = Cliente.LerClientes();
                    foreach(Cliente cliente in clientes)
                    {
                        Console.WriteLine(cliente.Nome);
                        Console.WriteLine(cliente.Telefone);
                        Console.WriteLine(cliente.CPF);
                        Console.WriteLine("==============");

                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida, tente novamente.");
                }
            }
        }
    }
}
