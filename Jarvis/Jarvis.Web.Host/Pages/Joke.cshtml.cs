using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Jarvis.Web.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jarvis.Web.Host.Pages
{
    public class JokeModel : PageModel
    {
        public List<JokeDto> Jokes { get; private set; }

        public async Task OnGet(int id = 0)
        {
            var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip });
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            var html = await client.GetStringAsync("http://joke.zaijiawan.com/Joke/joke2.jsp?appname=readingxiaonimei&version=4.2.0&os=ios&sort=1&timestamp=" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "&page=" + id);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            Jokes = doc.DocumentNode
                .SelectNodes("//root/joke").Select(x => new JokeDto
                {
                    Title = x.ChildNodes["name"].InnerText,
                    Content = x.ChildNodes["text"].InnerText,
                    Image = x.ChildNodes["imgurl"].InnerText,
                    Video = x.ChildNodes["videourl"]?.InnerText,
                }).ToList();
        }
    }
}