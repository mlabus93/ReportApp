using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAppTest.Tables
{
    class DimLocation
    {
        public int Location_Key { get; set; }
        public int Location_ID { get; set; }
        public char Location_Type { get; set; }
        public int Facility_Key { get; set; }
        public int Area_ID { get; set; }
        public string Area_Name { get; set; }
        public int Room_ID { get; set; }
        public string Room_Name { get; set; }
        public int Bed_ID { get; set; }
        public string Bed_Name { get; set; }
    }
}
