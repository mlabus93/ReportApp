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
        public const int SERVERS_COUNT = 15;
        public static DateTime printDateTime, startDate, endDate;
        public static String startTime, endTime;
        public static String[,] locations = new String[500, 15];
        public static List<String>[] location = new List<string>[15];
        public static int currentFacilityIndex = -1;

        public static void SetL(ListBox zones, ListBox rooms, string facility)
        {
            for (int i = 0; i < Properties.Settings.Default.Servers.Count; i++)
            {
                location[i] = new List<string>();
                if (Properties.Settings.Default.Facilities[i].Equals(facility, StringComparison.InvariantCultureIgnoreCase))
                {
                    currentFacilityIndex = i;
                }
            }
            foreach (var zone in zones.SelectedItems)
            {
                location[currentFacilityIndex].Add(((DataRowView)zone).Row["Zone_ID"].ToString());
            }
            foreach (var roomSelected in rooms.SelectedItems)
            {

                String.Join(", ", location[currentFacilityIndex]);
            }
        }

        private static void ConcatStrings(ListBox zones, ListBox rooms)
        {
            int state = 1;
            switch (state)
            {
                case 1:
                    foreach (var zone in zones.SelectedItems)
                    {
                        location[currentFacilityIndex].Add(((DataRowView)zone).Row["Zone_ID"].ToString());
                    }
                    state = 2;
                    break;
                case 2:
                    foreach (var room in rooms.SelectedItems)
                    {
                        location[currentFacilityIndex].Add(((DataRowView)room).Row["Room_ID"].ToString());
                        String.Join(", ", location[currentFacilityIndex]);
                    }
                    state = 1;
                    break;
            }
        }

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

        public static String CombineLocations(int serverIndex)
        {
            String parameter = "";
            for (int i=0; i < 500; i++)
            {
                if (locations[i,serverIndex] != null)
                {
                    parameter = parameter + locations[i, serverIndex] + " ";
                }
            }
            return parameter;
        }
    }
}
