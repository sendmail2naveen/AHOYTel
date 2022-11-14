using AHOYTel.LIB.Application;
using AHOYTEL.LIB.Models;

namespace AHOYTEL.API.Logic
{
    public class BookingProcessor : IBookingProcessor
    {
        private readonly IApiWorkflowManager apiWorkflowManager;
        public BookingProcessor(IApiWorkflowManager apiWorkflowManager)
        {
            this.apiWorkflowManager = apiWorkflowManager;
        }
        public async Task<HotelBookingResponse> ProcessHotelBookingRequest(HotelBookingRequest request)
        {
            try
            {
                var result = await apiWorkflowManager.ProcessHotelBookingWorkflow(request);
                return result;
            }
            catch (Exception ex)
            {
                //traceLogger.Error(ex, JsonConvert.SerializeObject(request));
                throw ex;
            }
            finally
            {
            }
        }
    }
}
