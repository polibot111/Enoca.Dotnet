using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Interface.Hangfire.Connection
{
    public interface IHangfireConnection
    {
        void EnsureHangfireDatabaseExists(string connectionString);
    }
}
