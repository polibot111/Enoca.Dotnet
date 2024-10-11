using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Carriers.Command.CreateCarriers
{
    public class CreateCarriersRequest : IRequest<IResponse>
    {
        [Required]
        public string CarrierName { get; set; }

        [Required]
        public bool CarrierIsActive { get; set; }

        [Required]
        public int CarrierPlusDesiCost { get; set; }

    }
}
