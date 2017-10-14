using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis.Core.Module
{
    public class HttpHelp : HttpClient
    {
        public static HttpClient DefaultClient { get; set; }

        static HttpHelp()
        {
            DefaultClient = new HttpClient(new HttpClientHandler {AutomaticDecompression = DecompressionMethods.GZip});
            DefaultClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            DefaultClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36");
        }
    }
}
