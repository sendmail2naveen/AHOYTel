using AHOYTel.Repository.DB;
using AHOYTEL.LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.LIB.Application.Services.Workflow.Tasks
{
    public class FinderTask : IHotelFinderTask
    {
        private readonly IHotelRepository _hotelRepository;
        public FinderTask(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<HotelFinderResponse> RunTask(HotelFinderRequest request, HotelFinderResponse result)
        {
            //string accessToken = JWToken.GetAccessToken(_accessTokenUrl, _scope, _clientId, _clientSecret).Result;
            HotelFinderResponse response = await Find(request);
            return response;
        }

        private async Task<HotelFinderResponse> Find(HotelFinderRequest request)
        {
            HotelFinderResponse hotelFinderResponse = new HotelFinderResponse();
            await _hotelRepository.LoadAsync(request.HotelId, QueryOperatorEnum.Equal);
            return hotelFinderResponse;
        }
    }
}