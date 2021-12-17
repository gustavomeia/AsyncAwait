using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {
        private static readonly Refatoracoes refatoracoes = new();
        private static readonly ConsoleColor defaultColor = ConsoleColor.White;
        public static async Task Main(string[] args)
        {
            EscreverAtencao("Iniciando");
            Console.WriteLine();

            await refatoracoes.Exemplo5(1);

            Console.WriteLine();
            EscreverAtencao("Finalizado");
            Console.ReadLine();
        }

        private static void Escrever(string texto, ConsoleColor cor = ConsoleColor.White)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(texto);
            Console.ForegroundColor = defaultColor;
        }

        public static void EscreverAtencao(string texto)
        {
            Escrever(texto, ConsoleColor.Yellow);
        }

        public static void EscreverErro(string texto)
        {
            Escrever(texto, ConsoleColor.Red);
        }

        public static void EscreverInfo(string texto)
        {
            Escrever(texto, ConsoleColor.Green);
        }
    }
}