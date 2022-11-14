using AHOYTel.LIB.Application.Services.Workflow.Tasks;
using AHOYTel.Repository.DB;
using AHOYTEL.LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.LIB.Application
{
    public class ApiWorkflowManager : IApiWorkflowManager
    {
        readonly List<IHotelSearchTask> hotelSearchTasks = new List<IHotelSearchTask>();
        readonly List<IHotelFinderTask> hotelFinderTasks = new List<IHotelFinderTask>();
        readonly List<IHotelBookingTask> hotelBookingTasks = new List<IHotelBookingTask>();
        public ApiWorkflowManager(IHotelRepository hotelRepository, IBookingRepository bookingRepository)
        {
            //add search related tasks
            hotelSearchTasks.Add(new SearchTask(hotelRepository));

            //add finder related tasks
            hotelFinderTasks.Add(new FinderTask(hotelRepository));
            hotelFinderTasks.Add(new DealsTask());
            hotelFinderTasks.Add(new ReviewsTask());
            hotelFinderTasks.Add(new FacilitiesTask());

            //add booking related tasks
            hotelBookingTasks.Add(new BookingTask(bookingRepository));
            hotelBookingTasks.Add(new InvoiceTask());
        }
        public async Task<HotelBookingResponse> ProcessHotelBookingWorkflow(HotelBookingRequest request)
        {
            HotelBookingResponse lastTaskResponse = new HotelBookingResponse() { };
            foreach (var task in hotelBookingTasks)
            {
                lastTaskResponse = await task.RunTask(request, lastTaskResponse);
            }
            return lastTaskResponse;
        }
        public async Task<HotelFinderResponse> ProcessHotelFinderWorkflow(HotelFinderRequest request)
        {
            HotelFinderResponse lastTaskResponse = new HotelFinderResponse() { };
            foreach (var task in hotelFinderTasks)
            {
                lastTaskResponse = await task.RunTask(request, lastTaskResponse);
            }
            return lastTaskResponse;
        }
        public async Task<List<HotelSearchResponse>> ProcessHotelSearchWorkflow(HotelSearchRequest request)
        {
            List<HotelSearchResponse> lastTaskResponse = new List<HotelSearchResponse>();
            foreach (var task in hotelSearchTasks)
            {
                lastTaskResponse = await task.RunTask(request);
            }
            return lastTaskResponse;
        }
    }
}
