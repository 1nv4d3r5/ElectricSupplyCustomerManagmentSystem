using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESCMSData
{

   public enum PostType
    {
        DataEnterer,
        Officer,
        Estimator,
        Admin
    }

    public class EmployeeInfo
    {
       public string id { get; set; }
       public string name { get; set; }
       public string address { get; set; }
       public string contact { get; set; }
       public PostType postType { get; set; }
       public DateTime doj { get; set; }
       public string department { get; set; }
    }
}
