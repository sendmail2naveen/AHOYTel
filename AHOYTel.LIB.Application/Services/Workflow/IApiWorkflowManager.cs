using AHOYTEL.LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.LIB.Application
{
    public interface IApiWorkflowManager
    {
        Task<List<HotelSearchResponse>> ProcessHotelSearchWorkflow(HotelSearchRequest request);
        Task<HotelFinderResponse> ProcessHotelFinderWorkflow(HotelFinderRequest request);
        Task<HotelBookingResponse> ProcessHotelBookingWorkflow(HotelBookingRequest request);
    }
}
