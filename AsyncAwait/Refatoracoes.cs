using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Refatoracoes
    {
        #region Exemplo 1

        public void Exemplo1()
        {
            Console.WriteLine("Inicio");

            AlgumMetodoAsync().Wait();

            Console.WriteLine("Fim");
        }

        #endregion Exemplo 1

        #region Exemplo 2 

        public async Task Exemplo2()
        {
            var clientesId = await BuscaIdsDeClientesAsync();

            foreach (var id in clientesId)
            {
                var nome = await BuscaNomesDeClientesAsync(id);
                Console.WriteLine($"{id}: {nome}");
            }
        }

        #endregion Exemplo 2

        #region Exemplo 3

        //Quando não usar .ConfigureAwait(false) - WpfExemplo

        #endregion

        #region Exemplo 4

        public async Task<bool> Exemplo4(int clienteId)
        {
            return await ClienteValidoAsync(clienteId);
        }

        #endregion

        #region Exemplo 5

        public Task<bool> Exemplo5(int clienteId)
        {
            try
            {
                return ClienteValidoAsync(clienteId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<string> Exemplo5_1()
        {
            using (var httpClient = new HttpClient())
            {
                return BaixarPaginaDoGoogle(httpClient);
            }

            //using var httpClient = new HttpClient();
            //return BaixarPaginaDoGoogle(httpClient);
        }

        #endregion

        #region Exemplo 6

        public List<object> Ordens;

        public Refatoracoes()
        {
            CarregarHistoricoDeOrdensAsync();
        }

        #endregion Exemplo 6

        #region Metodos Auxiliares

        public static async Task AlgumMetodoAsync()
        {
            await Task.Delay(1_000);
        }

        public static async Task AlgumMetodoComErroAsync()
        {
            await Task.Delay(1_000);
            throw new Exception("BUG 🐛");
        }

        public static async Task<List<int>> BuscaIdsDeClientesAsync()
        {
            await Task.Delay(1_000);
            return new List<int>();
        }

        public static async Task<List<string>> BuscaNomesDeClientesAsync(int id)
        {
            await Task.Delay(1_000);
            return new List<string>();
        }

        public static async Task<bool> ClienteValidoAsync(int id)
        {
            await Task.Delay(1_000);
            return true;
        }

        public static async Task<string> BaixarPaginaDoGoogle(HttpClient client)
        {
            await Task.Delay(1_000);
            var html = await client.GetStringAsync("http://google.com");
            return html;
        }

        public static async Task<List<string>> BuscaTodosClientesAsync()
        {
            await Task.Delay(1_000);
            return new List<string>();
        }

        public static async Task CarregarHistoricoDeOrdensAsync()
        {
            await Task.Delay(1_000);
        }

        #endregion Metodos Auxiliares
    }
}