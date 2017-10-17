using System.Threading.Tasks;
using Module.Dependency;

namespace Module
{
    /// <summary>
    /// 在启动时自动新建线程处理
    /// </summary>
    public interface ITaskHandle : ISingletonDependency
    {
        Task Handle();
    }
}
