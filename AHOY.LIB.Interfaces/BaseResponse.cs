using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTEL.LIB.Models
{
    public class BaseResponse
    {
        /// <summary>
        /// Request’s unique identifier that will be passed down to
        /// individual proxies and returned as part of the response.
        /// </summary>
        /// <example>BAC2AD70-67A9-4EAA-9678-5CA006D0D26D</example>
        public Guid TraceReferenceId { get; set; }
        /// <summary>
        /// Indicates the response time. 
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}
