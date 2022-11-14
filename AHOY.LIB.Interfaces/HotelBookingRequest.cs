using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTEL.LIB.Models
{
    public class HotelBookingRequest : BaseRequest
    {
        public string HotelId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public DateTime CheckIn{ get; set; }
        public DateTime CheckOut{ get; set; }
        public int NoOfRooms { get; set; }
        public int NoOfAdults { get; set; }
        public int NoOfChildern { get; set; }
        public List<Guest>Guests { get; set; }
    }
}
