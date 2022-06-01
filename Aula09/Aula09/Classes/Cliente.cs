using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Cliente
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="telefone"></param>
        /// <param name="cpf"></param>
        public Cliente(string nome, string telefone, string cpf)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.CPF = cpf;
        }
        


        /// <summary>
        /// Construtor sen parametros
        /// </summary>
        public Cliente() { }

        public string Nome;
        public string Telefone;
        public string CPF;

        private static string CaminhoBase()
        {
            return ConfigurationManager.AppSettings["BaseDeClientes"];
        }

        public static List<Cliente> LerClientes()
        {
            var clientes = new List<Cliente>();
            string arquivoComCaminho = CaminhoBase();

            if (File.Exists(arquivoComCaminho))
            {
                using (StreamReader arquivo = File.OpenText(arquivoComCaminho))
                {
                    string linha;
                    int i = 0;
                    while ((linha = arquivo.ReadLine()) != null)
                    {
                        i++;
                        if (i == 1) continue;
                        var ClienteArquivo = linha.Split(";");

                        var cliente = new Cliente(ClienteArquivo[0], ClienteArquivo[1], ClienteArquivo[2]);

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }


        public virtual void Gravar()
        {
            var clientes = Cliente.LerClientes();
            clientes.Add(this);
            string arquivoComCaminho = CaminhoBase();

            if (File.Exists(arquivoComCaminho))
            {
                string conteudo = "nome;telefone;cpf\n";

                foreach (Cliente c in clientes)
                {
                    conteudo += c.Nome + ";" + c.Telefone + ";" + c.CPF + ";\n";
                }

                File.WriteAllText(arquivoComCaminho, conteudo);
            }
            
        }

        private void Olhar()
        {
            Console.WriteLine("O cleinte " + this.Nome + "esta olhando para mim");
        }
    }
}
