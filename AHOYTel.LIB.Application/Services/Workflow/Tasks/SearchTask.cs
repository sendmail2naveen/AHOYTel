using AHOYTel.Repository.DB;
using AHOYTEL.LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.LIB.Application.Services.Workflow.Tasks
{
    internal class SearchTask : IHotelSearchTask
    {
        private readonly IHotelRepository _hotelRepository;
        public SearchTask(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<List<HotelSearchResponse>> RunTask(HotelSearchRequest request)
        {
            //string accessToken = JWToken.GetAccessToken(_accessTokenUrl, _scope, _clientId, _clientSecret).Result;
            List<HotelSearchResponse> response = await Search(request);
            return response;
        }

        private async Task<List<HotelSearchResponse>> Search(HotelSearchRequest request)
        {
            List<HotelSearchResponse> hotelSearchResponses = new List<HotelSearchResponse>();
            await _hotelRepository.QueryAsync(request.Name, QueryOperatorEnum.Contains, null);
            return hotelSearchResponses;
        }
    }
}