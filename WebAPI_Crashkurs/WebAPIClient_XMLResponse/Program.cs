using System;
using System.Net.Http; //HttpClient
using System.Net.Http.Headers; //MediaTypeWithQualityHeaderValue
using System.Threading.Tasks;

namespace WebAPIClient_XMLResponse
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://localhost:44387/api/People";


            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);

            string xml = await responseMessage.Content.ReadAsStringAsync();

            Console.WriteLine("Hello World!");
        }
    }
}
