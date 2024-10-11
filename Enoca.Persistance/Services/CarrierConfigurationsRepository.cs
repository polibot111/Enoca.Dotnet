using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.Core.Entities;
using Enoca.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistance.Services
{
    public class CarrierConfigurationsRepository : Repository<CarrierConfigurations>, ICarrierConfigurationsRepository
    {
        public CarrierConfigurationsRepository(MyDbContext myDb) : base(myDb)
        {
        }
    }
}
