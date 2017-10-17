using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Jarvis.Core.HttpData;
using Jarvis.Core.Module;
using Microsoft.EntityFrameworkCore;
using Module.Dependency;

namespace Jarvis.Core.Joke
{
    public class JokeFactory : ITransientDependency
    {
        //private readonly JarvisDbContext _dbContext;

        //private readonly HttpDataFactory _httpDataFactory;

        //public JokeFactory(JarvisDbContext dbContext, HttpDataFactory httpDataFactory)
        //{
        //    this._dbContext = dbContext;
        //    _httpDataFactory = httpDataFactory;
        //}

        //protected async Task<List<Joke>> GetJokes(DateTime date, int pageIndex)
        //{
        //    var html = await HttpHelp.DefaultClient.GetStringAsync("http://joke.zaijiawan.com/Joke/joke2.jsp?appname=readingxiaonimei&version=4.2.0&os=ios&sort=1&timestamp=" + date.ToString("yyyy-MM-dd hh:mm:ss") + "&page=" + pageIndex);
        //    var doc = new HtmlDocument();
        //    doc.LoadHtml(html);
        //    var jokes = doc.DocumentNode.SelectNodes("//root/joke");
        //    _httpDataFactory.SaveData(new HttpData.HttpData(jokes.Select(x => x.OuterHtml), SiteType.Joke));
        //    return jokes.Select(x => new Joke
        //    {
        //        Title = x.ChildNodes["text"].InnerText,
        //        ImageUrl = x.ChildNodes["imgurl"].InnerText,
        //        VideoUrl = x.ChildNodes["videourl"]?.InnerText,
        //        CreateTime = date
        //    }).ToList();
        //}

        ///// <summary>
        ///// 同步最新的数据持久化到数据库
        ///// </summary>
        ///// <returns></returns>
        //public async Task Sync()
        //{
        //    var jokes = await GetJokes(DateTime.Now, 0);
        //    await StoreJokes(jokes);
        //}

        ///// <summary>
        ///// 持久化数据
        ///// 如果存在 则过滤
        ///// </summary>
        ///// <param name="jokes"></param>
        ///// <returns></returns>
        //private async Task StoreJokes(List<Joke> jokes)
        //{
        //    var realJokes = new List<Joke>();

        //    foreach (var joke in jokes)
        //    {
        //        var entity = _dbContext.Jokes.AsNoTracking().FirstOrDefault(x => x.ImageUrl == joke.ImageUrl);
        //        if (entity == null)
        //            realJokes.Add(joke);
        //    }

        //    _dbContext.Jokes.AddRange(realJokes);
        //    await _dbContext.SaveChangesAsync();
        //}

        ///// <summary>
        ///// 同步历史数据 持久化到数据库
        ///// </summary>
        ///// <param name="pageIndex"></param>
        ///// <returns></returns>
        //public async Task SyncHistory(int pageIndex, DateTime? date = null)
        //{
        //    var jokes = await GetJokes(date ?? DateTime.Parse("2017-10-02 14:32:00"), pageIndex);
        //    await StoreJokes(jokes);
        //}
    }
}
