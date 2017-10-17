using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Jarvis.Web.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Init Web 阻塞方法
            BuildWebHost(args).Run();   
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }

}
