namespace Ex03.GarageLogic
{
     public class VehicleFactory
     {
          public Vehicle CreateVehicle(Vehicle.eVehicleType i_Type)
          {
               Vehicle newVehicle;
               if(i_Type == Vehicle.eVehicleType.Car)
               {
                    newVehicle = new Car();
               }
               else if(i_Type == Vehicle.eVehicleType.Motorcycle)
               {
                    newVehicle = new Motorcycle();
               }
               else if(i_Type == Vehicle.eVehicleType.Truck)
               {
                    newVehicle = new Truck();
               }
               else
               {
                    throw new System.FormatException();
               }
               return newVehicle;
          }
     }
}
