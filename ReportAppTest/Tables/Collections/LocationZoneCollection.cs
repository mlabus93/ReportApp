using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAppTest.Tables.Collections
{
    class LocationZoneCollection : IEnumerable<LocationZone>
    {
        private List<LocationZone> locationZoneCollection = new List<LocationZone>();

        public void AddLocationZone(LocationZone lz)
        {
            this.locationZoneCollection.Add(lz);
        }

        public IEnumerator<LocationZone> GetEnumerator() { return this.locationZoneCollection.GetEnumerator(); }
    }
}
