using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Hangfire.Services
{
    public interface IHangService
    {
        Task Fire();
    }
}
