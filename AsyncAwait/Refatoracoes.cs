using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Refatoracoes
    {
        //Exemplo 1 - Não usar .Wait() ou .Result
        public async Task Exemmplo1()
        {
            // Segura a thread até finalizar o método
            // OUtra thread rodando, ou seja, estamos usando 2 threads quando precisariamos usar apenas 1
            AlgumMetodoAsync().Wait();
        }


        //Exemplo 2 - ConfigureAwait(false)
        public async Task Exemmplo2()
        {
            var clientesId = await BuscaIdsDeClientesAsync();

            foreach (var id in clientesId)
            {
                var nome = await BuscaNomesDeClientesAsync(id);
                Console.WriteLine($"{id}: {nome}");
            }
        }

        //Exemplo 3 - não usar async async
        public async Task<bool> Exemmplo3(int clienteId)
        {
            return await ClienteValidoAsync(clienteId);
        }


        //Exemplo 4 - usar async await try/catch ou using
        public Task<bool> Exemmplo4(int clienteId)
        {
            try
            {
                return ClienteValidoAsync(clienteId);
            }
            catch (Exception ex)
            {
                //tratamento de ex
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<string> Exemmplo4_1()
        {
            using var httpClient = new HttpClient();
            return BaixarPaginaDoGoogle(httpClient);
        }

        //Exemplo 5 - Usar ValueTask
        //Quase uma task mas é uma struct e não uma classe, ou seja é tipo valor e não de referência, como isso ela vai pra stack e não pra heap, o que é menos custoso
        private List<string> _clientesEmCache;
        public async ValueTask<List<string>> Exemmplo5()
        {
            if (_clientesEmCache is not null)
                return _clientesEmCache;

            try
            {
                _clientesEmCache = await BuscaTodosClientesAsync();
                return _clientesEmCache;
            }
            catch (Exception ex)
            {
                //tratamento de ex
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Exemplo 6 - Contrutor fire and forget
        // Não consegue pegar exeção no try/catch
        // Intelisense pode induzir o erro a quem estiver utilizando o metodo
        // Concorrencia
        public List<object> Ordens;
        public Refatoracoes()
        {
            CarregarHistoricoDeOrdensAsync();
        }

        private async void CarregarHistoricoDeOrdens()
        {
            await CarregarHistoricoDeOrdensAsync();
        }


        #region Metodos de exemplo

        public async Task AlgumMetodoAsync()
        {
            await Task.Delay(1_000);
            //throw new Exception("BUG 🐛");
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

        #endregion
    }

    public static class TaskExtensions
    {
        public static async void FireAndForgetSafeAsync(this Task task, Action onCompleted, Action<Exception> errorHandler = null)
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
