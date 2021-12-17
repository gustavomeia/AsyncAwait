using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {
        private static readonly Refatoracoes refatoracoes = new();
        public static void Main(string[] args)
        {
            Exemplos.EscreverAtencao("Iniciando");
            Console.WriteLine();

            Console.WriteLine();
            Exemplos.EscreverAtencao("Finalizado");
            Console.ReadLine();
        }
    }
}