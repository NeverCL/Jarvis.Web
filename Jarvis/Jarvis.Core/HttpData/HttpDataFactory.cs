using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Module.Dependency;

namespace Jarvis.Core.HttpData
{
    public class HttpDataFactory : ITransientDependency
    {
        private JarvisDbContext _dbContext;
        public HttpDataFactory(JarvisDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void SaveData(HttpData data)
        {
            if (!_dbContext.HttpDatas.Any(x => x == data))
            {
                _dbContext.HttpDatas.Add(data);
                _dbContext.SaveChanges();
            }
        }
    }
}
