using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AHOYTEL.LIB.Models;
using AHOYTEL.API.Logic;
using System.Collections.Generic;

namespace AHOYTEL.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class SearchController : ControllerBase
    {
        private readonly ISearchProcessor _searchProcessor;

        public SearchController(ISearchProcessor searchProcessor)
        {
            _searchProcessor = searchProcessor;
        }

        [HttpPost]
        [ActionName("SearchHotels")]
        [ProducesResponseType(typeof(HotelSearchResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HotelSearchResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<HotelSearchResponse>>> SearchHotels(HotelSearchRequest request)
        {
            try
            {
                List <HotelSearchResponse> response = await _searchProcessor.ProcessHotelSearchRequest(request);
                return response;
            }
            catch (ArgumentException argumentEx)
            {
                return BadRequest(new { status = StatusCodes.Status400BadRequest, message = argumentEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [ActionName("FindHotel")]
        [ProducesResponseType(typeof(HotelFinderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HotelFinderResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HotelFinderResponse>> FindHotel(HotelFinderRequest request)
        {
            try
            {
                HotelFinderResponse response = await _searchProcessor.ProcessHotelFinderRequest(request);
                return response;
            }
            catch (ArgumentException argumentEx)
            {
                return BadRequest(new { status = StatusCodes.Status400BadRequest, message = argumentEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
