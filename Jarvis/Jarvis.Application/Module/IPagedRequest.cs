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
}
