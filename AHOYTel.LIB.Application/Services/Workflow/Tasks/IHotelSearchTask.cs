using AHOYTEL.LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.LIB.Application
{
    public interface IHotelSearchTask
    {
        Task<List<HotelSearchResponse>> RunTask(HotelSearchRequest request);
    }
}
