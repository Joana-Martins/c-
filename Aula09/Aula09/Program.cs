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
            Usuario u = new Usuario();
            u.Nome = "green";
            u.Telefone = "55555";
            u.CPF = "645454";
            u.Gravar();

            foreach (Usuario us in Usuario.LerUsuarios())
            {
                Console.WriteLine(us.Nome);
                Console.WriteLine(us.Telefone);
                Console.WriteLine(us.CPF);
            }
        }


    }

}