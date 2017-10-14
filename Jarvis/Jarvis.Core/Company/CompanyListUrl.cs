using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Jarvis.Core.Module;

namespace Jarvis.Core.Company
{
    public class CompanyListUrl : CreateEntity
    {
        protected CompanyListUrl()
        {
            
        }
        public CompanyListUrl(string url)
        {
            Url = url;
        }

        [StringLength(128)]
        public string Url { get; set; }

        public bool IsActive { get; set; }
    }
}
