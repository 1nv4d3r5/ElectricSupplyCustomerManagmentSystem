using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESCMSData
{
    public class NewConnectionInfo
    {
        public string appsNo { get; set; }
        public DateTime receivedDate { get; set; }

        public string paymentId { get; set; }
        public DateTime amountReceivedOn { get; set; }
        public double initialAmount { get; set; }

        public string customerId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }    
                
        public double quotationAmount { get; set; }
        public DateTime quotationSendDate { get; set; }

        public string serviceConnectionNo { get; set; }
    }
}
