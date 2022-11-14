using AHOYTel.Repository.DB;
using AHOYTEL.LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.LIB.Application.Services.Workflow.Tasks
{
    public class BookingTask : IHotelBookingTask
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingTask(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<HotelBookingResponse> RunTask(HotelBookingRequest request, HotelBookingResponse result)
        {
            //string accessToken = JWToken.GetAccessToken(_accessTokenUrl, _scope, _clientId, _clientSecret).Result;
            HotelBookingResponse response = await CreateBooking(request, result);
            return response;
        }
        private async Task<HotelBookingResponse> CreateBooking(HotelBookingRequest request, HotelBookingResponse result)
        {
            try
            {
                var bookingDomain = new Booking();//Need to Map ViewModel(HotelBookingRequest) to Domain Model(Booking)
                await _bookingRepository.SaveAsync(bookingDomain);
                //result = MapfromDomain()//Need to Map Domain Model(Booking) to ViewModel(HotelBookingRequest)
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
