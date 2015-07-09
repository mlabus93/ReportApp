using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportAppTest.Reports
{
    // Class for parameters used in Unit Activity Report
    public class UnitActivityReport
    {
        
        public string reportName, serverName;
        public string callTypeString;
        public const int SERVERS_COUNT = 15;
        public DateTime printDateTime, startDate, endDate;
        public String startTime, endTime;
        public static String[,] locations = new String[500, 15];
        public static List<String>[] location = new List<string>[15];
        public static int currentFacilityIndex = -1;
        public static string locationParamString { get; set; }
        public string locationString;
        


        public UnitActivityReport(string reportName)
        {
            this.reportName = reportName;
            SetServerName(reportName);
        }

        // Set server name for report
        private void SetServerName(string reportName)
        {
            int index = 0;

            // Loop to get index of facility/server
            foreach (var name in Properties.Settings.Default.Facilities)
            {
                if (name.Equals(reportName, StringComparison.InvariantCultureIgnoreCase))
                {
                    this.serverName = Properties.Settings.Default.Servers[index];
                }
                index++;
            }
        }  

    }
}
