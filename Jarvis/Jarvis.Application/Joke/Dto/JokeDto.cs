namespace Jarvis.Application.Joke.Dto
{
    public class JokeDto
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
    }
}
