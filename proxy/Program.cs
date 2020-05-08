using System;
using Agile.AServer;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;

namespace bproxy
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        private static string GetWebRequest(string getUrl)
        {
            string responseContent = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getUrl);

            request.Headers.Set("referer", "https://live.bilibili.com");
            request.Headers.Set("origin", "live.bilibili.com");
            request.ContentType = "application/json";
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //在这里对接收到的页面内容进行处理
            using (Stream resStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(resStream, Encoding.UTF8))
                {
                    responseContent = reader.ReadToEnd().ToString();
                }
            }
            return responseContent;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var server = new Agile.AServer.Server();
            server.AddHandler(new HttpHandler()
            {
                Method = "GET",
                Path = "/proxy/live",
                Handler = (req, resp) =>
                {
                    var url = "https://api.live.bilibili.com/xlive/web-room/v1/index/getInfoByRoom?";
                    // var burl = url + req.url.replace('/proxy/live', '')
                    foreach (var item in req.Query)
                    {
                        url += item.Key.ToString();
                        url += "=";
                        url += item.Value.ToString();
                        url += "&";
                    }
                    var res = GetWebRequest(url);
                    // Console.WriteLine(res);
                    return resp.Write(res);

                }
            });
            server.Run();
            Console.ReadLine();
        }
    }
}
