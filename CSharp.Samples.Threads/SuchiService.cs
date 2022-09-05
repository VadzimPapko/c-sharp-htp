using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace CSharp.Samples.Threads
{
    internal class SushiService : ISushiService
    {
        const string BaseUrl = "https://sushivesla.by/dishes";

        public async Task<List<dishMenus>>GetSushiAsync() 
        {
            HttpClient client = new HttpClient();

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5_000);

            List<dishMenus> menus = new List<dishMenus>();
            try
            {
                var data = await client.GetStringAsync(BaseUrl, cts.Token);
                var collection = JsonSerializer.Deserialize<SuchiResponse>(data);
                menus = collection?.Data?.Menus;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            finally 
            {
                client.Dispose();
            }

            return menus;
        }
    }
}
