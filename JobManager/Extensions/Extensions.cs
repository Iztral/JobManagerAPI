using JobManager.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManager.Extensions
{
    public static class Extensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginationFilter paginationFilter)
        {
            return query.Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                        .Take(paginationFilter.PageSize);           
        }
    
    }
}
