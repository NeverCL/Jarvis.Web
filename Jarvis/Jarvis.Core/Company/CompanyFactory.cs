using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Core.Module;
using Microsoft.EntityFrameworkCore;

namespace Jarvis.Core.Company
{
    public class CompanyFactory
    {
        private readonly JarvisDbContext _dbContext;

        public CompanyFactory(JarvisDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 根据企业信息页URL地址创建存储企业信息
        /// 已经存在的企业数据修改信息
        /// !! 暂时不做更新处理
        /// </summary>
        /// <param name="url">支持Id 和 URL 2种方式</param>
        /// <returns></returns>
        public async Task CreateCompany(string url)
        {
            try
            {
                url = url.StartsWith("http") ? url : "https://www.tianyancha.com/company/" + url;
                var thirdCode = url.Substring(35);
                // !! 暂时不做更新处理
                if (await _dbContext.Companies.AsNoTracking().AnyAsync(x => x.ThirdCode == thirdCode))
                    return;

                var html = await HttpHelp.DefaultClient.GetStringAsync(url);
                var doc = new HtmlHelp(html);

                var entity = new Company
                {
                    ThirdCode = thirdCode,
                    Name = doc.SingleInnerText("//span[@class='f18 in-block vertival-middle sec-c2']"),
                    Mobile = doc.SingleInnerText("//div[@class='f14 sec-c2 mt10']/div[@class='in-block vertical-top overflow-width mr20']/span[2]"),
                    TrustCode = doc.SingleInnerText("//div[@class='base0910']/table[@class='table companyInfo-table f14']/tbody/tr[2]/td[2]"),
                    Address = doc.SingleInnerText("//div[@class='base0910']/table[@class='table companyInfo-table f14']/tbody/tr[5]/td[4]"),
                    Site = doc.SingleInnerText("//a[@class='c9']"),
                    LegalUser = doc.SingleInnerText("//div[@class='f18 overflow-width sec-c3']/a"),
                    RegisteredCapital = doc.SingleInnerText("//td[2]/div[@class='new-border-bottom']/div[@class='pb10']/div[@class='baseinfo-module-content-value']"),
                    RegisteredTime = DateTime.Parse(doc.SingleInnerText("//td[2]/div[@class='new-border-bottom pt10']/div[@class='pb10']/div[@class='baseinfo-module-content-value']"))
                };
                if (await _dbContext.Companies.AsNoTracking().AnyAsync(x => x.TrustCode == entity.TrustCode))
                {
                    var company = await _dbContext.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.TrustCode == entity.TrustCode);
                    entity.Id = company.Id;
                    entity.CreateTime = DateTime.Now;
                    _dbContext.Update(entity);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    _dbContext.Companies.Add(entity);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 1. 根据企业查询列表页URL地址获取所有企业信息
        /// </summary>
        /// <param name="listUrl">查询URL参数 或 查询完整URL地址</param>
        /// <returns></returns>
        public async Task CreateCompanys(string listUrl)
        {
            listUrl = listUrl.StartsWith("http") ? listUrl : "https://www.tianyancha.com/search/" + listUrl;
            var html = await HttpHelp.DefaultClient.GetStringAsync(listUrl);
            var doc = new HtmlHelp(html);
            var urls = doc.SelectNodes("//a[@class='query_name sv-search-company f18 in-block vertical-middle']", "href");
            var tasks = new List<Task>();
            foreach (var url in urls)
            {
                var task = CreateCompany(url);
                await task;
                tasks.Add(task);
            }
            //await Task.WhenAll(tasks);
        }

        /// <summary>
        /// 激活数据库中的URL地址 
        /// 为空 取数据库第一条数据 
        /// 真实地址且数据库中存在 判断数据库状态
        /// 真实地址且数据库中不存在 插入数据库
        /// </summary>
        /// <param name="listUrl">为空 或 真实地址</param>
        /// <returns></returns>
        public async Task ActiveCompanyListUrl(string listUrl)
        {
            if (string.IsNullOrEmpty(listUrl))
            {
                listUrl = (await _dbContext.CompanyListUrls.AsNoTracking().FirstOrDefaultAsync(x => !x.IsActive))?.Url;
                if (string.IsNullOrEmpty(listUrl))
                    return;
            }

            var entity = await _dbContext.CompanyListUrls.AsNoTracking().FirstOrDefaultAsync(x => x.Url == listUrl && !x.IsActive);
            if (entity == null)
            {
                entity = new CompanyListUrl(listUrl);
                _dbContext.CompanyListUrls.Add(entity);
                await _dbContext.SaveChangesAsync();
            }

            await CreateCompanys(listUrl);
            entity.IsActive = true;
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
