using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTEL.LIB.Models
{
    public class Invoice
    {
        public double BasePrice { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double ServiceFee { get; set; }
        public double Insurance { get; set; }
        public string CouponCode { get; set; }
        public int PaymentId { get; set; }
        public string TransactionId { get; set; }
    }
}
