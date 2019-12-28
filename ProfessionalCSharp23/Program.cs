using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Routing;

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

        #region 23.2.5用HttpMessageHandler自定义请求

        public class SampleMessageHandler : HttpClientHandler
        {
            private string _message;
            public SampleMessageHandler(string message) => _message = message;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                Console.WriteLine(_message);
                if (_message=="error")
                {
                    var response=new HttpResponseMessage(HttpStatusCode.BadRequest);
                    return Task.FromResult<HttpResponseMessage>(response);
                }
                return base.SendAsync(request, cancellationToken);
            }
        }


        #endregion

        #region 23.3使用WebListener类

        public static async Task StartServerAsync(params string[] prefixes)
        {
            try
            {
                Console.WriteLine($"server starting at");
                var listener = new WebListener();
                foreach (var prefix in prefixes)
                {
                    listener.UrlPrefixes.Add(prefix);
                    Console.WriteLine($"\t{prefix}");
                }
                listener.Start();
                do
                {
                    using (RequestContext context=await listener.GetContextAsync())
                    {
                        context.Response.Headers.Add("content-type", new string[] {"text/html"});
                    }
                } while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
  
        #endregion
    }
}
