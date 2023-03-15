using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public class DriverBus
    {
        public int DriverId { get; set; }
        public int BusId { get; set; }
        public Driver Driver { get; set; }
        public Bus Bus { get; set; }

        public DriverBus(int driverId, int busId)
        {
            DriverId = driverId;
            BusId = busId;
        }

        public DriverBus()
        {

        }


    }
}
