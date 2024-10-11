using Enoca.ApplicationLayer.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Commons
{
    public static class PaginationChanger
    {
        public static WrapperPaginationResponse<T> PaginationDataChange<T, C>(List<T> data, WrapperPaginationResponse<C> entity)
        {
            WrapperPaginationResponse<T> wrapperPaginationResponse = new WrapperPaginationResponse<T>()
            {
                Data = data,
                Page = entity.Page,
                Size = entity.Size,
                TotalCount = entity.TotalCount,
                Succeeded = entity.Succeeded,
                Message = entity.Message
            };

            return wrapperPaginationResponse;
        }

        public static WrapperPaginationResponse<T> PaginationDataChange<T, C>(List<T> data, WrapperQuereblePaginationResponse<C> entity)
        {
            WrapperPaginationResponse<T> wrapperPaginationResponse = new WrapperPaginationResponse<T>()
            {
                Data = data,
                Page = entity.Page,
                Size = entity.Size,
                TotalCount = entity.TotalCount,
                Succeeded = entity.Succeeded,
                Message = entity.Message
            };

            return wrapperPaginationResponse;
        }
    }
}
