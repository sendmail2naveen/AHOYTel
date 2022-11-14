using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace AHOYTel.Repository.DB
{
    [DynamoDBTable("ahoytel-table")]
    public class Hotel
    {
        [DynamoDBProperty("pk", typeof(HotelIdKeyConverter))]
        public string HotelId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int NoOfReviews { get; set; }
        public int NoOfAvailableRooms { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Description { get; set; }
        public string FacilitiesRawText { get; set; }
        public double Rate { get; set; }
        public string ReviewsRawText { get; set; }
        public string DealsRawText { get; set; }
    }
}
