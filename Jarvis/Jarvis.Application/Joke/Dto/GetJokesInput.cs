using System;
using System.Collections.Generic;
using System.Text;
using Jarvis.Application.Module;

namespace Jarvis.Application.Joke.Dto
{
    public class GetJokesInput : IPagedRequest
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
