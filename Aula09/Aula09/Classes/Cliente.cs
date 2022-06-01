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

        private static string caminhoBaseClientes()
        {
            return ConfigurationManager.AppSettings["BaseDeClientes"];
        }

        private static string caminhoBaseUsuarios()
        {
            return ConfigurationManager.AppSettings["BaseDeUsuarios"];
        }

        public static List<Cliente> LerClientes()
        {
            var clientes = new List<Cliente>();
            string arquivoComCaminho = caminhoBaseClientes();

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

        public static List<Usuario> LerUsuarios()
        {
            var usuarios = new List<Usuario>();
            string arquivoComCaminhoUsuario = caminhoBaseUsuarios();

            if (File.Exists(arquivoComCaminhoUsuario))
            {
                using (StreamReader arquivo = File.OpenText(arquivoComCaminhoUsuario))
                {
                    string linha;
                    int i = 0;
                    while ((linha = arquivo.ReadLine()) != null)
                    {
                        i++;
                        if (i == 1) continue;
                        var UsuarioArquivo = linha.Split(";");

                        var usuario = new Usuario(UsuarioArquivo[0], UsuarioArquivo[1], UsuarioArquivo[2]);

                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }

        public void Gravar()
        {
            if (this.GetType() == typeof(Cliente))
            {

                var clientes = Cliente.LerClientes();
                clientes.Add(this);
                string arquivoComCaminho = caminhoBaseClientes();

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
            else
            {
                var usuarios = Usuario.LerUsuarios();
                Usuario u = new Usuario(this.Nome, this.Telefone, this.CPF);
                usuarios.Add(u);
                string arquivoComCaminhoUsuario = caminhoBaseUsuarios();

                if (File.Exists(arquivoComCaminhoUsuario))
                {
                    string conteudo = "nome;telefone;cpf\n";

                    foreach (Usuario c in usuarios)
                    {
                        conteudo += c.Nome + ";" + c.Telefone + ";" + c.CPF + ";\n";
                    }

                    File.WriteAllText(arquivoComCaminhoUsuario, conteudo);

                }
            }
        }

        private void Olhar()
        {
            Console.WriteLine("O cleinte " + this.Nome + "esta olhando para mim");
        }
    }
}
