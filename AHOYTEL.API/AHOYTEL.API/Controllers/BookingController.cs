using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AHOYTEL.LIB.Models;
using AHOYTEL.API.Logic;

namespace AHOYTEL.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class BookingController : ControllerBase
    {
        private readonly IBookingProcessor _bookingProcessor;

        public BookingController(IBookingProcessor bookingProcessor)
        {
            _bookingProcessor = bookingProcessor;
        }

        [HttpPost]
        [ActionName("BookHotel")]
        [ProducesResponseType(typeof(HotelBookingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HotelBookingResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HotelBookingResponse>> BookHotel(HotelBookingRequest request)
        {
            try
            {
                HotelBookingResponse response = await _bookingProcessor.ProcessHotelBookingRequest(request);
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
