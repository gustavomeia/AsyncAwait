using AsyncAwait;
using System;
using System.Threading.Tasks;

namespace ExecucaoParalela
{
    class Program
    {
        private readonly static Exemplos exemplos = new();

        static async Task Main(string[] args)
        {
            Console.WriteLine("#### INICIO DO PROCESSAMENTO PARALELO ####");
            Console.WriteLine();

            await AtualizarInformacoesParaleloAsync();

            Console.WriteLine();
            Console.WriteLine("#### FIM DO PROCESSAMENTO PARALELO ####");
            Console.ReadKey();
        }

        public static async Task AtualizarInformacoesParaleloAsync()
        {
            exemplos.IniciarContador();

            var taskCartaoCredito = exemplos.AtualizarCartaoCreditoAsync();
            var taskContaCorrente = exemplos.AtualizarContaCorrenteAsync();
            var taskContaInvestimento = exemplos.AtualizarContaInvestimentoAsync();

            await Task.WhenAll(taskCartaoCredito, taskContaCorrente, taskContaInvestimento);

            exemplos.PararContador();
        }
    }
}
