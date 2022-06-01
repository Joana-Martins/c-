using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Classes
{
     public class Usuario : Cliente
    {
        public Usuario(string nome, string telefone, string cpf)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.CPF = cpf;
        }
        public Usuario() { }

        private static string CaminhoBase()
        {
            return ConfigurationManager.AppSettings["BaseDeUsuarios"];
        }

        public override void Gravar()
        {
            var usuarios = Usuario.LerUsuarios();
            Usuario u = new Usuario(this.Nome, this.Telefone, this.CPF);
            usuarios.Add(u);
            string arquivoComCaminhoUsuario = CaminhoBase();

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

        public static List<Usuario> LerUsuarios()
        {
            var usuarios = new List<Usuario>();
            string arquivoComCaminhoUsuario = CaminhoBase();

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
    }
}
