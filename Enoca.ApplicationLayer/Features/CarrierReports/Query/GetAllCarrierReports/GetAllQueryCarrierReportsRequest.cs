using Enoca.ApplicationLayer.Commons;
using Enoca.ApplicationLayer.Features.Carriers.Query.GetAllCarriers;
using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierReports.Query.GetAllCarrierReports
{
    public class GetAllQueryCarrierReportsRequest : PaginationDateRequest, IRequest<IWrapperPaginationResponse<GetAllQueryCarrierReportsResponse>>
    {
    }
}
