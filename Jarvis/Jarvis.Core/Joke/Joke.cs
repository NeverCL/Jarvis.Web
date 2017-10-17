using Module.Domain.Entities;

namespace Jarvis.Core.Joke
{
    public class Joke : CreateEntity
    {
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
    }
}
