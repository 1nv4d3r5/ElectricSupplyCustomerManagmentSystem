using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESCMSData
{
    public enum AngleType
    {
        Short,
        Long
    }

    public class estimateInfo
    {
        public string appsNo { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public string estimator { get; set; }
        public double initialAmount { get; set; }
        public double wireLength { get; set; }
        public double angleWeight { get; set; }
        public AngleType angleType { get; set; }
        public double quotationAmount { get; set; }
        public string contractor { get; set; }
    }
}
