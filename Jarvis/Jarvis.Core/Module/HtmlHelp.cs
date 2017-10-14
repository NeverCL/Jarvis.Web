using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Jarvis.Core.Module
{
    public class HtmlHelp : HtmlDocument
    {
        public HtmlHelp(string html)
        {
            this.LoadHtml(html);
        }

        public string SingleInnerText(string xpath)
        {
            return DocumentNode
                .SelectSingleNode(xpath)
                ?.InnerText;
        }

        public List<string> SelectNodes(string xpath, string attrName)
        {
            return DocumentNode
                .SelectNodes(xpath).Select(x => x.Attributes[attrName].Value).ToList();
        }

    }
}
