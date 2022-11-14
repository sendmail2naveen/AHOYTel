using AHOYTEL.LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.LIB.Application.Services.Workflow.Tasks
{
    public class FacilitiesTask : IHotelFinderTask
    {
        public Task<HotelFinderResponse> RunTask(HotelFinderRequest request, HotelFinderResponse result)
        {
            return Task.FromResult(result);
        }
    }
}