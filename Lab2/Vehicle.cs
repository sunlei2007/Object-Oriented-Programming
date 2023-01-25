using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Vehicle
    {
        private string _licenseNumber;
        public string LicenseNumber
        {
            get
            {
                return _licenseNumber;
            }
            set { 
                if (value.Length < 2 || value.Length > 7) 
                {
                    throw new Exception("LicenseNumber need great than 2 and less than 8");
                }
                _licenseNumber = value;
             }
        }

        public ParkingSpot? VehicleParkingSpot { get; set; }
        public Vehicle(string licenseNumber)
        {
            LicenseNumber = licenseNumber;
        }
    }
}
