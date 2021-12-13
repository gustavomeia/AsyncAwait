using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Exemplos
    {
        private readonly Stopwatch stopwatch = new();

        public async Task AtualizarInformacoesParaleloAsync()
        {
            IniciarContador();

            var taskCartaoCredito = AtualizarCartaoCreditoAsync();
            var taskContaCorrente = AtualizarContaCorrenteAsync();
            var taskContaInvestimento = AtualizarContaInvestimentoAsync();
            await Task.WhenAll(taskCartaoCredito, taskContaCorrente, taskContaInvestimento);

            PararContador();
        }

        public async Task AtualizarInformacoesParaleloComErroAsync()
        {
            IniciarContador();

            var taskCartaoCredito = AtualizarCartaoCreditoAsync();
            var taskContaCorrente = AtualizarContaCorrenteAsync();
            var taskAtualizacaoComErroAsync = AtualizacaoComErroAsync();
            var taskContaInvestimento = AtualizarContaInvestimentoAsync();

            try
            {
                await Task.WhenAll(taskCartaoCredito, taskContaCorrente, taskAtualizacaoComErroAsync, taskContaInvestimento);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            PararContador();
        }

        public async Task AtualizarInformacoesSequencialAsync()
        {
            IniciarContador();

            await AtualizarCartaoCreditoAsync();
            await AtualizarContaCorrenteAsync();
            await AtualizarContaInvestimentoAsync();

            PararContador();
        }

        private static async Task AtualizacaoComErroAsync()
        {
            await Task.Delay(100);
            throw new Exception("BUG 🕷️");
        }

        private static async Task AtualizarCartaoCreditoAsync()
        {
            Console.WriteLine("Atualizando Cartão de Crédito...");
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine("Limite do Cartão de Crédito: R$ 2400,00");
        }

        private static async Task AtualizarContaCorrenteAsync()
        {
            Console.WriteLine("Atualizando Conta Corrente...");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Saldo em Conta Corrente: R$ 500,00");
        }

        private static async Task AtualizarContaInvestimentoAsync()
        {
            Console.WriteLine("Atualizando Conta Investimento...");
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("Você tem R$ 6.000,00 aplicado em sua Conta Investimento");
        }

        private void IniciarContador() => stopwatch.Restart();

        private void PararContador()
        {
            stopwatch.Stop();
            Console.WriteLine($"Tempo Execução: {stopwatch.Elapsed.Seconds}s");
        }
    }
}
