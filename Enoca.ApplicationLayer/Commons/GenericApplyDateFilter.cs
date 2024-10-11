using Enoca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Commons
{
    public static class GenericApplyDateFilter
    {
        public static IQueryable<T> ApplyDateFilter<T>(IQueryable<T> query,
                                              DateTime? startDate,
                                              DateTime? endDate ) where T : BaseEntity
                                           
        {
            if (startDate != null && endDate != null)
            {
                query = query.Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate);
            }
            else if (startDate != null)
            {
                query = query.Where(x => x.CreatedDate >= startDate);
            }
            else if (endDate != null)
            {
                query = query.Where(x => x.CreatedDate <= endDate);
            }

            return query;
        }
    }
}
