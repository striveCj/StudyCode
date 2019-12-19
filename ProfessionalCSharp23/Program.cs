using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp23
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        #region 23.2.1发出异步的Get请求

        private const string NorthwindUrl = "http://services.data.org/Northwind/Northwind.svc/Regions";

        private const  string IncorrectUrl= "http://services.data.org/Northwind1/Northwind.svc/Regions";

        private HttpClient _httpClient;

        public HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());

        private async Task GetDataSimpleAsync()
        {
            HttpResponseMessage responese = await HttpClient.GetAsync(NorthwindUrl);
            if (responese.IsSuccessStatusCode)
            {
                Console.WriteLine($"{(int)responese.StatusCode}{responese.ReasonPhrase}");
                string respomseBpdyAsText = await responese.Content.ReadAsStringAsync();
                Console.WriteLine($"Received payload of{respomseBpdyAsText.Length}characters ");
                Console.WriteLine();
                Console.WriteLine(respomseBpdyAsText);
            }
        }

        #endregion
    }
}
