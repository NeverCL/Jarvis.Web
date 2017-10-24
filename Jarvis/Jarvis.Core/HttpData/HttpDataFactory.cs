using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Module.Dependency;
using Module.Domain.Repository;

namespace Jarvis.Core.HttpData
{
    public class HttpDataFactory : ITransientDependency
    {
        private readonly IRepository<HttpData, long> _httpDataRepository;

        public HttpDataFactory(IRepository<HttpData, long> httpDataRepository)
        {
            _httpDataRepository = httpDataRepository;
        }

        public List<object> GetDataList()
        {
            var data = _httpDataRepository.GetAll().ToList();
            return null;
        }
        

        //public void SaveData(HttpData data)
        //{
        //    if (!_httpDataRepository.Any(x => x == data))
        //    {
        //        _httpDataRepository.Add(data);
        //    }
        //}
    }
}
