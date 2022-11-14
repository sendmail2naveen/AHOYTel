using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTEL.LIB.Models
{
    public class HotelSearchResponse : BaseResponse
    {
        public string HotelId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double Rating { get; set; }
        public int NoOfReviews { get; set; }
        public byte[] Thumbnail { get; set; }
        public double Rate { get; set; }
    }
}