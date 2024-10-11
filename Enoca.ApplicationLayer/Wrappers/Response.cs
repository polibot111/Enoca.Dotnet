using Enoca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Wrappers
{
    public class Response<T> : IResponse<T>
    {
        public Response(T data, bool succeeded, string message)
        {
            Data = data;
            Succeeded = succeeded;
            Message = message;
        }

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public TimeSpan? ElipsedTime { get; set; }
    }

    public class Response : IResponse
    {
        public Response()
        {

        }
        public Response(bool value, string message)
        {
            Succeeded = value;
            Message = message;
        }
        public TimeSpan? ElipsedTime { get; set; }
        public bool Succeeded { get; set; } = true;
        public string Message { get; set; } = "Islem Basarili";

    }

    public class WrapperPaginationResponse<T> : IWrapperPaginationResponse<T>
    {
        public WrapperPaginationResponse()
        {
            
        }

        public WrapperPaginationResponse(List<T> data, bool succeeded, string message, int totalcount, int page, int size)
        {
            Data = data;
            Succeeded = succeeded;
            Message = message;
            TotalCount = totalcount;
            Page = page;
            Size = size;
        }
        public TimeSpan? ElipsedTime { get; set; }
        public List<T> Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }

    public class WrapperQuereblePaginationResponse<T> : IWrapperPaginationResponse<T>
    {
        public WrapperQuereblePaginationResponse()
        {
            
        }
        public WrapperQuereblePaginationResponse(IQueryable<T> data, bool succeeded, string message, int totalcount, int page, int size)
        {
            Data = data;
            Succeeded = succeeded;
            Message = message;
            TotalCount = totalcount;
            Page = page;
            Size = size;
        }
        public TimeSpan? ElipsedTime { get; set; }
        public IQueryable<T> Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }

    public static class ResponseFactory
    {
        public static Response<T> CreateResponse<T>(T data, bool succeeded, string message)
        {
            return new Response<T>(data, succeeded, message);
        }

        public static Response<T> CreateResponse<T>(T data)
        {
            return new Response<T>(data, true, "Islem Basarili");
        }


        public static Response CreateResponse(bool value)
        {

            if (value)
            {
                return new Response(true, "Islem Basarili");
            }
            else
            {
                return new Response(false, "Islem Basarisiz");
            }

        }

  
    }

}
