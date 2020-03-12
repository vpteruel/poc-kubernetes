using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace lambda3.console
{
    class Program
    {
        // private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await GetData();
            Console.ReadLine();
            Console.ReadKey();
        }

        // private static async Task GetData()
        // {
        //     client.DefaultRequestHeaders.Accept.Clear();
        //     client.DefaultRequestHeaders.Add("User-Agent", "Lambda3 Console Request");

        //     var stringTask = client.GetStringAsync("https://localhost:5001/values");

        //     var msg = await stringTask;
        //     Console.Write(msg);
        // }

        private static async Task GetData()
        {
            string baseUrl = "https://localhost:5001/values";

            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.SslProtocols = SslProtocols.Tls12;
            handler.ClientCertificates.Add(new X509Certificate2());
            handler.CheckCertificateRevocationList = false;
            handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => { return true; };

            using (HttpClient client = new HttpClient(handler))
            using (HttpResponseMessage res = await client.GetAsync(baseUrl))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    Console.WriteLine(data);
                }
            }
        }
    }
}
