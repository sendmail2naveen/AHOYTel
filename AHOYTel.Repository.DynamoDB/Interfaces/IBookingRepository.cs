using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.Repository.DB
{
    public interface IBookingRepository
    {
        Task<Booking> SaveAsync(Booking booking);
    }
}
