using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTEL.LIB.Models
{
    public class HotelFinderResponse : BaseResponse
    {
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
        public List<Facility> Facilities { get; set; }
        public double Rate { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Deal> Deals { get; set; }
    }
}
