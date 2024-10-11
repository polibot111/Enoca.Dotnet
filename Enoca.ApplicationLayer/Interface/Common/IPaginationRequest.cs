using Enoca.ApplicationLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Interface.Common
{
    public interface IPaginationRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public OrderByEnum OrderBy { get; set; } 
    }
}
