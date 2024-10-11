using Enoca.ApplicationLayer.Enums;
using Enoca.ApplicationLayer.Interface.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Commons
{
    public class PaginationDateRequest : IPaginationDateRequest
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = -1;
        public OrderByEnum OrderBy { get; set; }
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
    }
}
