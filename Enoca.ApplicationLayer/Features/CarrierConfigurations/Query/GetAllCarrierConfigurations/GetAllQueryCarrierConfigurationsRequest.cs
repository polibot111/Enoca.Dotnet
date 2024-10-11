using Enoca.ApplicationLayer.Commons;
using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierConfigurations.Query.GetAllCarrierConfigurations
{
    public class GetAllQueryCarrierConfigurationsRequest : PaginationDateRequest, IRequest<IWrapperPaginationResponse<GetAllQueryCarrierConfigurationsResponse>>
    {

    }
}
