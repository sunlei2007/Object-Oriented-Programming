using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class CarPark
    {
        public HashSet<ParkingSpot> hsParkingSpot =new HashSet<ParkingSpot>();

        public CarPark(int capacity)
        {
            for(int i = 1; i <= capacity; i++)
            {
                ParkingSpot parkingSpot = new ParkingSpot(i);
                parkingSpot.SpotCarPark = this;
                hsParkingSpot.Add(parkingSpot);
            }
            
        }

        public void ParkVehicle(string licenseNumber)
        {

            foreach(var parkingSpot in hsParkingSpot)
            {
               if( parkingSpot.SpotVehicle ==null)
                {
                    Vehicle vehicle = new Vehicle(licenseNumber);
                    vehicle.VehicleParkingSpot = parkingSpot;
                    parkingSpot.SpotVehicle = vehicle;

                    break;
                    
                }
            }

        }
        public void RemoveVehicle(string licenseNumber)
        {
            foreach (var parkingSpot in hsParkingSpot)
            { 
                if(parkingSpot.SpotVehicle.LicenseNumber== licenseNumber)
                {
                    parkingSpot.SpotVehicle.VehicleParkingSpot = null;
                    parkingSpot.SpotVehicle = null;
                    break;
                }
            }
         }
    }
}
