using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        #region 23.2.2 抛出异常

        private async Task GetDataWithExceptionsAsync()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync(IncorrectUrl);
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"Response Status Code{(int)response.StatusCode}{response.ReasonPhrase}");
                string responseBodyAsText = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"{responseBodyAsText.Length}");
                Console.WriteLine();
                Console.WriteLine(responseBodyAsText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        #endregion

        #region 23.2.1传递标题

        //public Task GetDataWIthinHeadersAsync()
        //{
        //    try
        //    {
        //        HttpClient.DefaultRequestHeaders.Add("Accept","application/json;odata=varbose");
        //        ShowHeaders("Request Headers:", HttpClient.DefaultRequestHeaders);
        //        HttpResponseMessage response = await HttpClient.GetAsync(NorthwindUrl);
        //        HttpClient.EnsureSuccessStatusCode();
        //        ShowHeaders("Request Headers:", HttpClient.DefaultRequestHeaders);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
   
        //    }
        //}

        //public void ShowHeaders(string title, HttpHeaders headers)
        //{
        //    Console.WriteLine(title);
        //    foreach (var header in headers)
        //    {
        //        string value = string.Join(" ", header.Value);
        //        Console.WriteLine($"Header:{header.Key} Value:{value}");
        //    }
        //    Console.WriteLine();
        //}

        #endregion
    }
}
