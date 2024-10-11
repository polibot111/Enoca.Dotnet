using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.DeleteCarrierConfigurations
{
    public class DeleteCarrierConfigurationsRequest : IRequest<IResponse>
    {
        public int Id { get; set; }
        internal bool SavaChanges { get; set; } = true;
    }
}
