using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class RefatoracoesFinalizadas
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        #region Exemplo 1 - Não usar .Wait() ou .Result
        // NUNCA USE
        // DeadLock - Depende do ambiente (Console, .NET Core WebApp, ASP.NET, Desktop app) 
        // Segura a thread até finalizar o método
        // Outra thread é iniciada, ou seja, estamos usando 2 threads quando precisariamos usar apenas 1

        public async Task Exemplo1()
        {
            Console.WriteLine("Inicio");

            await AlgumMetodoAsync();

            Console.WriteLine("Fim");
        }

        #endregion Exemplo 1 - Não usar .Wait() ou .Result

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        #region Exemplo 2 - ConfigureAwait(false)

        public async Task Exemplo2()
        {
            var clientesId = await BuscaIdsDeClientesAsync().ConfigureAwait(false);

            foreach (var id in clientesId)
            {
                var nome = await BuscaNomesDeClientesAsync(id).ConfigureAwait(false);
                Console.WriteLine($"{id}: {nome}");
            }
        }

        #endregion Exemplo 2 - ConfigureAwait(false)

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        #region Exemplo 3

        //Quando não usar .ConfigureAwait(false) - WpfExemplo

        #endregion Exemplo 3

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        #region Exemplo 4 - Não utilizar async await

        // por não utilizar a palavra await, não mudamos de contexto, como isso ganhamos performance
        // tbm economizamos uns 100 bytes de codigo (gerado pelo C# para método async) que não muda praticamente nada :D
        public Task<bool> Exemplo4(int clienteId)
        {
            return ClienteValidoAsync(clienteId);
        }

        #endregion Exemplo 4 - Não utilizar async await

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        #region Exemplo 5 - Utilizar async await

        public async Task<bool> Exemplo5(int clienteId)
        {
            try
            {
                return await ClienteValidoAsync(clienteId);
            }
            catch (Exception ex)
            {
                //tratamento de ex
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<string> Exemplo5_1()
        {
            using var httpClient = new HttpClient();
            return await BaixarPaginaDoGoogle(httpClient);

            //using (var httpClient = new HttpClient())
            //{
            //    return await BaixarPaginaDoGoogle(httpClient);
            //}
        }

        #endregion Exemplo 5 - Utilizar async await

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        #region Exemplo 6 - Safe Fire and Forget ou Factory Pattern

        //public List<object> Ordens;

        // Criar método async void
        // Problema 1: Não consegue pegar exeção no try/catch

        // Problema 2: Concorrecia

        // Problema 3: Alta complexidade para testes
        // Como não tem como aguardar o método terminar, não temos como saber quando ele terminou para fazer as validações
        // Existe frameworks para ajudar nesses casos, mas é muito mais complexo do que utilizar um await e fazer as validações

        // Problema 4: Intellisense pode induzir o erro a quem estiver utilizando o metodo
        // Quando esse método for utilizado por outro programador, o intellisense vai dizer que ele é um void
        // ou seja, a pessoa vai concluir que a proxima linha só vai ser executada quando o método finalizar, o que não é vdd

        // Solução 1 - Safe fire and forget
        //public RefatoracoesFinalizadas()
        //{
        //    CarregarHistoricoDeOrdensAsync().FireAndForgetSafeAsync(OnCompleted, OnError);
        //}

        //private void OnError(Exception ex)
        //{
        //    // tratamento de erro
        //    Console.WriteLine(ex.Message);
        //}

        //private void OnCompleted()
        //{
        //    Console.WriteLine($"CarregarHistoricoDeOrdensAsync Finalizado");
        //}

        // Solução 2 - Factory Pattern
        private RefatoracoesFinalizadas()
        {
        }

        public static async Task<RefatoracoesFinalizadas> CriarRefatoracoesFinalizadasAsync()
        {
            var refatoracoesFinalizadas = new RefatoracoesFinalizadas();
            await refatoracoesFinalizadas.CarregarHistoricoDeOrdensAsync();
            return refatoracoesFinalizadas;
        }

        #endregion Exemplo 6 - Safe Fire and Forget ou Factory Pattern

        #region Metodos de exemplo

        public async Task AlgumMetodoAsync()
        {
            await Task.Delay(1_000);
        }

        public async Task<List<int>> BuscaIdsDeClientesAsync()
        {
            await Task.Delay(1_000);
            return new List<int>();
        }

        public async Task<List<string>> BuscaNomesDeClientesAsync(int id)
        {
            await Task.Delay(1_000);
            return new List<string>();
        }

        public async Task<bool> ClienteValidoAsync(int id)
        {
            await Task.Delay(1_000);
            return true;
        }

        public async Task<string> BaixarPaginaDoGoogle(HttpClient client)
        {
            await Task.Delay(1_000);
            var html = await client.GetStringAsync("http://google.com");
            return html;
        }

        public async Task<List<string>> BuscaTodosClientesAsync()
        {
            await Task.Delay(1_000);
            return new List<string>();
        }

        public async Task CarregarHistoricoDeOrdensAsync()
        {
            await Task.Delay(1_000);
        }

        #endregion Metodos de exemplo
    }

    public static class TaskExtensions
    {
        public static async void FireAndForgetSafeAsync(
            this Task task,
            Action onCompleted,
            Action<Exception> errorHandler = null)
        {
            try
            {
                await task;
                onCompleted?.Invoke();
            }
            catch (Exception ex)
            {
                errorHandler?.Invoke(ex);
            }
        }
    }
}