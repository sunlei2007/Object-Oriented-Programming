using Lab2;

CarPark carPark = new CarPark(20);

//Add vehicle
carPark.ParkVehicle("A00001");
carPark.ParkVehicle("A00002");
carPark.ParkVehicle("A00003");

foreach (var parkingSpot in carPark.hsParkingSpot)
{
    if (parkingSpot.SpotVehicle != null)
    {
        Console.WriteLine($"Spot{parkingSpot.SpotNumber} has vehicle {parkingSpot.SpotVehicle.LicenseNumber}");
       
    }
    else
    {
        Console.WriteLine($"Spot{parkingSpot.SpotNumber}  has  no vehicle !");

    }

}

Console.WriteLine("-------------------------");

//Remove  vehicle
carPark.RemoveVehicle("A00001");
foreach (var parkingSpot in carPark.hsParkingSpot)
{
    if (parkingSpot.SpotVehicle != null)
    {
        Console.WriteLine($"Spot{parkingSpot.SpotNumber} has vehicle {parkingSpot.SpotVehicle.LicenseNumber}");

    }
    else
    {
        Console.WriteLine($"Spot{parkingSpot.SpotNumber}  has  no vehicle !");

    }

}