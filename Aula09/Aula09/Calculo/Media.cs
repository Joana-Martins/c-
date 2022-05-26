using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo
{
    internal class Media
    {
        public static void Aluno()
        {
            Console.WriteLine("Digite o nome do aluno: ");
            string nome = Console.ReadLine();
            int qtdNotas = 3;
            int media = 0;
            int total = 0;
            Console.WriteLine("Digite as " + qtdNotas + " notas do aluo");
            List<int> notas = new List<int>();
            for (int i = 1; i <= qtdNotas; i++)
            {
                Console.WriteLine("Digite a nota " + i + ": ");
                int nota = int.Parse(Console.ReadLine());
                total += nota;
                notas.Add(nota);
            }

            media = total / notas.Count;
            Console.WriteLine("\n A média do aluno " + nome + " é: " + media);
            Console.WriteLine("Suas notas são: ");
            foreach (int nota in notas)
            {
                Console.WriteLine("Nota: " + nota);
            }

        }
    }
}
