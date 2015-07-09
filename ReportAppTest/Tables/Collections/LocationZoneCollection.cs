using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportAppTest.Tables.Collections
{
    public class LocationZoneCollection : IEnumerable<LocationZone>
    {
        private List<LocationZone> locationZoneCollection = new List<LocationZone>();

        public void AddLocationZone(LocationZone lz)
        {
            this.locationZoneCollection.Add(lz);
        }

        public string CreateParameterString()
        {
            string parameterString = "";
            foreach (var lz in locationZoneCollection)
            {
                parameterString += lz.Zone_ID.ToString() + "," + lz.Room_ID.ToString() + ";";
            }
            return parameterString;
        }

        public string CreateParameterString(ListBox zones, ListBox rooms)
        {
            string parameterString = "";
            foreach (var lz in locationZoneCollection)
            {
                
                parameterString += lz.Zone_ID.ToString() + "," + lz.Room_ID.ToString() + ";";
            }
            return parameterString;
        }

        public List<LocationZone> GetList()
        {
            return locationZoneCollection;
        }

        public List<LocationZone> GetZoneList()
        {
            List<LocationZone> temp = new List<LocationZone>();
            foreach (var lz in locationZoneCollection)
            {
                if (!DuplicateZoneExists(temp, lz.Zone_Name))
                    temp.Add(lz);
            }
            return temp;
        }

        public List<LocationZone> GetRoomList(string zoneName)
        {
            List<LocationZone> temp = new List<LocationZone>();
            foreach (var lz in locationZoneCollection)
            {
                if (zoneName.Equals("All", StringComparison.InvariantCultureIgnoreCase))
                {
                    string roomName = lz.Room_Name;
                    if (!DuplicateRoomExists(temp, roomName))
                        temp.Add(lz);
                }
                else if (lz.Zone_Name.Equals(zoneName, StringComparison.InvariantCultureIgnoreCase))
                {
                    string roomName = lz.Room_Name;
                    if (!DuplicateRoomExists(temp, roomName))
                        temp.Add(lz);
                }
            }
            return temp;
        }

        public List<LocationZone> GetRoomList(ListBox zoneLB)
        {
            List<LocationZone> temp = new List<LocationZone>();
            foreach (var zone in zoneLB.SelectedItems)
            {
                
                
                string currentZoneString = zoneLB.GetItemText(zone);
                foreach (var lz in locationZoneCollection)
                {
                    if (currentZoneString.Equals("All", StringComparison.InvariantCultureIgnoreCase))
                    {
                        string roomName = lz.Room_Name;
                        if (!DuplicateRoomExists(temp, roomName))
                            temp.Add(lz);
                    }
                    else if (lz.Zone_Name.Equals(currentZoneString, StringComparison.InvariantCultureIgnoreCase))
                    {
                        string roomName = lz.Room_Name;
                        if (!DuplicateRoomExists(temp, roomName))
                            temp.Add(lz);
                    }
                }
            }
            return temp;
        }

        private bool DuplicateRoomExists(List<LocationZone> temp, string roomName)
        {
            foreach (var lz in temp)
            {
                if (lz.Room_Name.Equals(roomName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        private bool DuplicateZoneExists(List<LocationZone> temp, string zoneName)
        {
            foreach (var lz in temp)
            {
                if (lz.Zone_Name.Equals(zoneName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }


        public IEnumerator<LocationZone> GetEnumerator() { return this.locationZoneCollection.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
