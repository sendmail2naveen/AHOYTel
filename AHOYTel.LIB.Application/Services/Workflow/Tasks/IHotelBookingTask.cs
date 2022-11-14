using AHOYTEL.LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.LIB.Application
{
    public interface IHotelBookingTask
    {
        Task<HotelBookingResponse> RunTask(HotelBookingRequest request, HotelBookingResponse lastResult);
    }
}
