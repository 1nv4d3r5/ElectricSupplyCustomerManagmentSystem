using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESCMSData
{
    public class PaymentInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string customerId { get; set; }
        public double amount { get; set; }
        public DateTime dop { get; set; }
    }
}
