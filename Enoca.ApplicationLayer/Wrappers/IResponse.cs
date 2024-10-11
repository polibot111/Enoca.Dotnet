using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Wrappers
{
    public interface IResponse
    {
        public TimeSpan? ElipsedTime { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }

    public interface IResponse<T> : IResponse
    {
        public T Data { get; set; }

    }

    public interface IPagination
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

    }
    public interface IWrapperPaginationResponse<T> : IPagination, IResponse
    {

    }
}
