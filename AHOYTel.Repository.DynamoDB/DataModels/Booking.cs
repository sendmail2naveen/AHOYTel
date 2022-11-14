using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace AHOYTel.Repository.DB
{
    [DynamoDBTable("ahoytel-table")]
    public class Booking
    {
        [DynamoDBProperty("pk", typeof(BookingIdKeyConverter))]
        public string BookingId { get; set; }
        [DynamoDBRangeKey("sk", typeof(HotelIdKeyConverter))]
        public string HotelId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NoOfRooms { get; set; }
        public int NoOfAdults { get; set; }
        public int NoOfChildern { get; set; }
        public string GuestsRawText { get; set; }
    }
}
