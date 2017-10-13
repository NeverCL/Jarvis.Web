using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Jarvis.Core.Joke
{
    public class JokeFactory
    {
        public async Task<List<Joke>> Build(DateTime date, int pageIndex)
        {
            var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip });
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            var html = await client.GetStringAsync("http://joke.zaijiawan.com/Joke/joke2.jsp?appname=readingxiaonimei&version=4.2.0&os=ios&sort=1&timestamp=" + date.ToString("yyyy-MM-dd hh:mm:ss") + "&page=" + pageIndex);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode
                .SelectNodes("//root/joke").Select(x => new Joke
                {
                    Title = x.ChildNodes["text"].InnerText,
                    ImageUrl = x.ChildNodes["imgurl"].InnerText,
                    VideoUrl = x.ChildNodes["videourl"]?.InnerText,
                }).ToList();
        }
    }
}
