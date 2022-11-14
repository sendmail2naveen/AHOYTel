using AHOYTEL.LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.LIB.Application.Services.Workflow.Tasks
{
    public class InvoiceTask : IHotelBookingTask
    {
        public Task<HotelBookingResponse> RunTask(HotelBookingRequest request, HotelBookingResponse result)
        {
            return Task.FromResult(result);
        }
    }
}