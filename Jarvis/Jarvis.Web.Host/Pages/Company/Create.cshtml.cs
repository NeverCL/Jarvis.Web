using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Core;
using Jarvis.Core.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jarvis.Web.Host.Pages.Company
{
    public class CreateModel : PageModel
    {
        private JarvisDbContext _dbContext;

        public CreateModel(JarvisDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void OnGet(string url)
        {
            _dbContext.CompanyListUrls.Add(new CompanyListUrl(url));
            _dbContext.SaveChanges();
        }
    }
}