using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace OlmeLabs.LogAggregator.SampleClient
{
    internal class Program
    {
        private static readonly Uri BaseApiAddr = new Uri("http://localhost:65423/api/");

        private static void Main()
        {
            var uid = Guid.NewGuid();
            var msg = $"{DateTime.Now} - Sample message {uid}";

            PostSampleLog(msg);

            SearchLogs(uid.ToString());
        }

        private static void PostSampleLog(string message)
        {
            var logEntry = new
            {
                Sys = "SystemUnqId",
                Env = "PROD",
                Severity = "Info",
                Content = message
            };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BaseApiAddr;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var res = client.PostAsJsonAsync("Log", logEntry).Result;
            }
        }

        private static void SearchLogs(string keywords)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs["keywords"] = keywords;
            qs["PageSize"] = "20";
            qs["CurrentPage"] = "1";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BaseApiAddr;
                var res = client.GetAsync($"search?{qs}").Result;

                using (StreamReader sr = new StreamReader(res.Content.ReadAsStreamAsync().Result))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
}

