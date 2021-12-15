using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Exemplos
    {
        private readonly Stopwatch stopwatch = new();

        public async Task AtualizacaoComErroAsync()
        {
            await Task.Delay(100);
            throw new Exception("BUG 🕷️");
        }

        public async Task AtualizarCartaoCreditoAsync()
        {
            Console.WriteLine("Atualizando Cartão de Crédito...");
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine("Limite do Cartão de Crédito: R$ 2400,00");
        }

        public async Task AtualizarContaCorrenteAsync()
        {
            Console.WriteLine("Atualizando Conta Corrente...");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Saldo em Conta Corrente: R$ 500,00");
        }

        public async Task AtualizarContaInvestimentoAsync()
        {
            Console.WriteLine("Atualizando Conta Investimento...");
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("Você tem R$ 6.000,00 aplicado em sua Conta Investimento");
        }

        public void IniciarContador() => stopwatch.Restart();

        public void PararContador()
        {
            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Tempo Execução: {stopwatch.Elapsed.Seconds}s");
        }
    }
}