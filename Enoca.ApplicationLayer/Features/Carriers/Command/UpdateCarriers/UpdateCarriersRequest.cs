using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Carriers.Command.UpdateCarriers
{
    public class UpdateCarriersRequest : IRequest<IResponse>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CarrierName { get; set; }

        [Required]
        public bool CarrierIsActive { get; set; }

        [Required]
        public int CarrierPlusDesiCost { get; set; }


    }
}
