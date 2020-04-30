using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp15
{
    class Program
    {
        static void Main(string[] args)
        {
            SynchronizedAPI();
            AsynchronousPattern();
        }

        private const string url = "http://www.cninnovation.com";
        private static void SynchronizedAPI()
        {
            Console.WriteLine(nameof(SynchronizedAPI));
            using (var client=new WebClient())
            {
                string content = client.DownloadString(url);
                Console.WriteLine(content.Substring(0,100));
            }
            Console.WriteLine();
        }

        private static void AsynchronousPattern()
        {
            Console.WriteLine(nameof(AsynchronousPattern));
            WebRequest request = WebRequest.Create(url);
            IAsyncResult result = request.BeginGetResponse(ReadResponse, null);
            void ReadResponse(IAsyncResult ar)
            {
                using (WebResponse response=request.EndGetResponse(ar))
                {
                    Stream stream = response.GetResponseStream();
                    var reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content.Substring(0,100));
                    Console.WriteLine();
                }
            }
        }
    }
}
