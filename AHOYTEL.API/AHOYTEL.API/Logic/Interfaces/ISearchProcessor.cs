using AHOYTEL.LIB.Models;

namespace AHOYTEL.API.Logic
{
    public interface ISearchProcessor
    {
        Task<List<HotelSearchResponse>> ProcessHotelSearchRequest(HotelSearchRequest request);
        Task<HotelFinderResponse> ProcessHotelFinderRequest(HotelFinderRequest request);
    }
}
