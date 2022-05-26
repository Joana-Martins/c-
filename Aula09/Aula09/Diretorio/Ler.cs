using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Diretorio
{
    internal class Arquivo
    {
        private static string caminhoArquivo()
        {
            return ConfigurationManager.AppSettings["CaminhoArquivo"];
        }
        public static void Ler(int numArquivo)
        {
            string arquivoComCaminho = caminhoArquivo() + numArquivo + ".txt";
            if (File.Exists(arquivoComCaminho))
            {
                using (StreamReader arquivo = File.OpenText(arquivoComCaminho))
                {
                    string linha;
                    while ((linha = arquivo.ReadLine()) != null)
                    {
                        Console.WriteLine(linha);
                    }
                }
            }

            string arquivoCaminho2 = caminhoArquivo() + (numArquivo + 1) + ".txt";
            if (File.Exists(arquivoCaminho2))
            {
                Ler(numArquivo + 1);
            }
        }
    }
}
