using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Module.EntityFrameworkCore
{
    public interface IDbContextProvider<out TDbContext> where TDbContext : DbContext
    {
        /// <summary>
        /// 获取DbContext
        /// </summary>
        /// <returns></returns>
        TDbContext GetDbContext();
    }
}
