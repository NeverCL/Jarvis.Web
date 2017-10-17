using Jarvis.Core.Module;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace Jarvis.Core.HttpData
{
    public class HttpData : CreateEntity<long>
    {
        public HttpData()
        {

        }

        public HttpData(object data, SiteType type)
        {
            Data = JsonConvert.SerializeObject(data);
            Type = type;
        }

        public string Data { get; set; }

        public SiteType Type { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is HttpData)
                return ((HttpData) obj).Data == this.Data && ((HttpData) obj).Type == this.Type;
            return false;
        }
    }

    public enum SiteType
    {
        /// <summary>
        /// 搞笑妹子
        /// </summary>
        Joke = 0,

    }
}
