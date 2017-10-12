using System;
using System.Collections.Generic;
using System.Text;

namespace Jarvis.Core
{
    public class Joke
    {
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// 视频内容
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }


        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
