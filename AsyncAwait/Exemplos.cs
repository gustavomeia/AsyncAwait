using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Exemplos
    {
        private readonly Stopwatch stopwatch = new();

        public async Task AtualizarCartaoCreditoAsync()
        {
            Console.WriteLine("Atualizando Cartão de Crédito...");
            await Task.Delay(TimeSpan.FromSeconds(3));
            EscreverInfo("Limite do Cartão de Crédito: R$ 2400,00");
        }

        public async Task AtualizarContaCorrenteAsync()
        {
            Console.WriteLine("Atualizando Conta Corrente...");
            await Task.Delay(TimeSpan.FromSeconds(5));
            EscreverInfo("Saldo em Conta Corrente: R$ 500,00");
        }

        public async Task AtualizarContaInvestimentoAsync()
        {
            Console.WriteLine("Atualizando Conta Investimento...");
            await Task.Delay(TimeSpan.FromSeconds(2));
            EscreverInfo("Você tem R$ 6.000,00 aplicado em sua Conta Investimento");
        }

        public void IniciarContador() => stopwatch.Restart();

        public void PararContador()
        {
            stopwatch.Stop();
            Console.WriteLine();
            EscreverErro($"Tempo Execução: {stopwatch.Elapsed.Seconds}s");
        }

        #region Escrever em tela
        private static readonly ConsoleColor defaultColor = ConsoleColor.White;

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
        #endregion
    }
}