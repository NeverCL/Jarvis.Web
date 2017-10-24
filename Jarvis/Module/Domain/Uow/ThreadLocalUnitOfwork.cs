using System.Threading;
using Module.Dependency;

namespace Module.Domain.Uow
{
    public class ThreadLocalUnitOfwork : ITransientDependency
    {
        //private const string ContextKey = "UnitOfWork.Current";
        private static IUnitOfWork _unitOfWork;

        public ThreadLocalUnitOfwork(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly ThreadLocal<IUnitOfWork> _threadUnitOfWork = null;

        private IUnitOfWork GetCurrentUow()
        {
            if (_threadUnitOfWork.IsValueCreated)
            {
                return _threadUnitOfWork.Value;
            }
            else
            {
                _threadUnitOfWork.Value = _unitOfWork;
            }
            return _threadUnitOfWork.Value;
        }
    }
}
