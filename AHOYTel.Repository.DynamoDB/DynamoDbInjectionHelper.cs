using Amazon.DynamoDBv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AHOYTel.Repository.DB
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public static class DynamoDbInjectionHelper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBookingRepository, BookingRepository>();
            services.AddSingleton<IHotelRepository, HotelRepository>();
        }
    }
}
