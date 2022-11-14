using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.Repository.DB
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public BookingRepository(IAmazonDynamoDB amazonDynamoDb, IDynamoDBContext dynamoDBContext) : base(amazonDynamoDb, dynamoDBContext)
        {
        }
        public async Task<Booking> SaveAsync(Booking booking)
        {
            var data = booking;//dataMapper.ToBooking(booking);//Need to do Mapping
            await dynamoDBContext.SaveAsync(data);
            return data;
        }

    }
}
