
using BestHTTP;
using System.Threading;
using System.Threading.Tasks;
using System;
namespace Ja3ClientTest
{
    internal class Program
    {
        static    void Main(string[] args)
        {
            HTTPManager.JA3Settings = new BestHTTP.TlsClientExtensions.Ja3Settings();
            var request = new HTTPRequest(new Uri("https://tls.browserleaks.com/json"));
            request.DisableCache = true;

            var str = request.GetAsStringAsync().Result;
            Console.WriteLine(str);

            Test();
            Console.Read();

        }

        private static void Test()
        {
            var request = new HTTPRequest(new Uri("https://m.beqege.cc"));
            request.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/113.0.0.0");

            request.AddHeader("Accept-Agent", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.AddHeader("refer", "https://m.beqege.cc/");
            var html = request.GetAsStringAsync().Result;
            Console.WriteLine(html);
        }
    }
}