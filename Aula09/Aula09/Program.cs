using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tela;
using Classes;

namespace index
{
    class Program
    { 

        static void Main(string[] args)
        {
            //Menu.Criar();
            
            var clientes = Cliente.LerClientes();
            var cliente = new Cliente();
            cliente.Nome = "laila";
            cliente.Telefone = "27981089213";
            cliente.CPF = "78985245623";
            cliente.Gravar();
            
            foreach(Cliente c in clientes)
            {
                Console.WriteLine(c.Nome);
            }
        }


    }

}