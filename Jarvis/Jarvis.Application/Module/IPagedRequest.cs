using System;
using System.Collections.Generic;
using System.Text;

namespace Jarvis.Application.Module
{
    public interface IPagedRequest
    {
        int PageIndex { get; set; }

        int PageSize { get; set; }
    }

    public abstract class PagedRequest : IPagedRequest
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
