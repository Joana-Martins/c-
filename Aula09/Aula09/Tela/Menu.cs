using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculo;
using Diretorio;
using Funcoes;

namespace Tela
{
    internal class Menu
    {

        public const int SAIDA_PROGRAMA = 0;
        public const int LER_ARQUIVOS = 1;
        public const int TABUADA = 2;
        public const int CALCULO_MEDIA = 3;
        public const int CADASTRAR_CLIENTES = 4;
        public static void Criar()
        {
            while (true)
            {
                string mensagem = "\nOlá, usuário, bem vindo ao programa\n" +
                "\n  Utilizando programação funcional" +
                "\n\n" +
                "\n     Digite uma das opções abaixo:" +
                "\n         0 - Sair do programa" +
                "\n         1 - Para Ler arquivos" +
                "\n         2 - Calcular tabuada" +
                "\n         3 - Calcular média de alunos" +
                "\n         4 - Cadastrar clientes";
                Console.WriteLine(mensagem);

                int valor = int.Parse(Console.ReadLine());

                if (valor == SAIDA_PROGRAMA)
                {
                    Console.WriteLine("============== Saindo do Programa ===============");
                    break;
                }
                else if (valor == LER_ARQUIVOS)
                {
                    Console.WriteLine("============== Lendo Arquivos ===============");
                    Arquivo.Ler(1);
                    Console.WriteLine("\n=======================================\n");
                }
                else if (valor == TABUADA)
                {
                    Console.WriteLine("============== Fazendo a tabuada ===============");
                    int num;
                    Console.WriteLine("Digite o numero para obter a tabuada");
                    num = int.Parse(Console.ReadLine());
                    Tabuada.Calcular(num);
                    Console.WriteLine("\n=======================================\n");
                }
                else if (valor == CALCULO_MEDIA)
                {
                    Console.WriteLine("============== Calculando a media ===============");
                    Media.Aluno();
                    Console.WriteLine("\n=======================================\n");
                }
                else if (valor == CADASTRAR_CLIENTES)
                {
                    TelaCliente.Chamar();
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite novamente\n\n");
                }
            }
        }
    }
}
