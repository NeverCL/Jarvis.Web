using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jarvis.Application.Module
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Used for paging. Can be used as an alternative to Skip(...).Take(...) chaining.
        /// </summary>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            return query.Skip<T>(skipCount).Take<T>(maxResultCount);
        }

        /// <summary>
        /// Used for paging with an <see cref="T:Abp.Application.Services.Dto.IPagedResultRequest" /> object.
        /// </summary>
        /// <param name="query">Queryable to apply paging</param>
        /// <param name="pagedRequest">An object implements <see cref="T:Abp.Application.Services.Dto.IPagedResultRequest" /> interface</param>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, IPagedRequest pagedRequest)
        {
            return query.PageBy<T>((pagedRequest.PageIndex - 1) * pagedRequest.PageSize, pagedRequest.PageSize);
        }
    }
}
