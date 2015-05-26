using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportAppTest.Reports
{
    public  static class UnitActivityReport
    {
        public static DateTime printDateTime, startDate, endDate;
        public static String startTime, endTime;
        public static String[,] locations = new String[500, 15];


        public static void SetLocations( ListBox zones, ListBox rooms, string facility)
        {
            int facilityIndex = -1;
            for (int j = 0; j < Properties.Settings.Default.Facilities.Count; j++ )
            {
                if (Properties.Settings.Default.Facilities[j].Equals(facility, StringComparison.InvariantCultureIgnoreCase))
                {
                    facilityIndex = j;
                    break;
                }
            }
            int i = 0;
            var selectedZones = zones.SelectedItems;
            var selectedRooms = rooms.SelectedItems;
            foreach (var item in selectedZones)
            {
                locations[i, facilityIndex] = ((DataRowView)item).Row["Zone_ID"].ToString();
                //locations[i] = (String)itemArray;
                //i++;
                //var id = itemArray[1];
                //locations[i] =  + ", ";
                i++;
            }
            i = 0;
            foreach (var room in selectedRooms)
            {
                locations[i, facilityIndex] = locations[i, facilityIndex] + ", " + ((DataRowView)room).Row["Room_ID"].ToString() + ";";
                i++;
            }
        }
    }
}
