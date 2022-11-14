using AHOYTel.LIB.Application;
using AHOYTEL.LIB.Models;
using Newtonsoft.Json;

namespace AHOYTEL.API.Logic
{
    public class SearchProcessor : ISearchProcessor
    {
        private readonly IApiWorkflowManager apiWorkflowManager;
        public SearchProcessor(IApiWorkflowManager apiWorkflowManager)
        {
            this.apiWorkflowManager = apiWorkflowManager;
        }
        public async Task<List<HotelSearchResponse>> ProcessHotelSearchRequest(HotelSearchRequest request)
        {
            try
            {
                var result = await apiWorkflowManager.ProcessHotelSearchWorkflow(request);
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
        public async Task<HotelFinderResponse> ProcessHotelFinderRequest(HotelFinderRequest request)
        {
            try
            {
                var result = await apiWorkflowManager.ProcessHotelFinderWorkflow(request);
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
