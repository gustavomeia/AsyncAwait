using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await AtualizarInformacoesSequencialAsync();
            await AtualizarInformacoesParaleloAsync();
            await AtualizarInformacoesParaleloComErroAsync();

            Console.WriteLine("#### FIM DA APLICAÇÃO ####");
            Console.ReadLine();
        }

        private static void AguardarInicioTeste(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.ReadLine();
        }

        private static async Task AtualizarInformacoesParaleloAsync()
        {
            AguardarInicioTeste($"#### Aguardando para iniciar {nameof(Exemplos.AtualizarInformacoesParaleloAsync)}...");

            var exemplos = new Exemplos();
            await exemplos.AtualizarInformacoesParaleloAsync();
        }

        private static async Task AtualizarInformacoesParaleloComErroAsync()
        {
            AguardarInicioTeste($"#### Aguardando para iniciar {nameof(Exemplos.AtualizarInformacoesParaleloComErroAsync)}...");

            var exemplos = new Exemplos();
            await exemplos.AtualizarInformacoesParaleloComErroAsync();
        }

        private static async Task AtualizarInformacoesSequencialAsync()
        {
            AguardarInicioTeste($"#### Aguardando para iniciar {nameof(Exemplos.AtualizarInformacoesSequencialAsync)}...");

            var exemplos = new Exemplos();
            await exemplos.AtualizarInformacoesSequencialAsync();
        }
    }
}
