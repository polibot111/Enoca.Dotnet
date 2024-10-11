using Enoca.ApplicationLayer.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Interface.Common
{
    public interface IPaginationDateRequest : IPaginationRequest, IDateFilterRequest
    {
    }
}
