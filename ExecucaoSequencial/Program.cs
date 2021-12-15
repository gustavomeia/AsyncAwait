using AsyncAwait;
using System;
using System.Threading.Tasks;

namespace ExecucaoSequencial
{
    class Program
    {
        private readonly static Exemplos exemplos = new();

        static async Task Main(string[] args)
        {
            Console.WriteLine("#### INICIO DO PROCESSAMENTO SEQUENCIAL ####");
            Console.WriteLine();

            await AtualizarInformacoesSequencialAsync();

            Console.WriteLine();
            Console.WriteLine("#### FIM DO PROCESSAMENTO SEQUENCIAL ####");
            Console.ReadKey();
        }

        public static async Task AtualizarInformacoesSequencialAsync()
        {
            exemplos.IniciarContador();

            await exemplos.AtualizarCartaoCreditoAsync();
            await exemplos.AtualizarContaCorrenteAsync();
            await exemplos.AtualizarContaInvestimentoAsync();

            exemplos.PararContador();
        }
    }
}
