using System.Threading.Tasks;
using AHOYTEL.LIB.Models;

namespace AHOYTEL.API.Logic
{
    public interface IBookingProcessor
    {
        Task<HotelBookingResponse> ProcessHotelBookingRequest(HotelBookingRequest request);
    }
}
