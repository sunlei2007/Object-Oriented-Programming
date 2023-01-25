using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class ParkingSpot
    {
        public int SpotNumber { get; set; }
        public Vehicle? SpotVehicle { get; set; }
        public CarPark SpotCarPark { get; set; }

        public ParkingSpot(int spotNumber)
        {
            SpotNumber = spotNumber;
        }
    }
}
