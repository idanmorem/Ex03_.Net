
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
         private readonly Dictionary<Vehicle, string> r_VehiclesInGarage;

         public GarageLogic()
         {
             r_VehiclesInGarage = new Dictionary<Vehicle, string>();
         }
          public enum eGarageOperations
          {
               InsertNewVehicle,
               ListLicencedVehicles,
               ChangeVehicleState,
               AddTirePressure,
               FillGasMotor,
               FillElectricMotor,
               ExhibitSpecificCar,
               QuitApp
          }

          public void AddFuel(string i_ID, eFuelType i_fuelType, float i_amountToFill)
          { 
              //options:
            //1. if amount is invalid throw
            //2. set fuel -> incase of invalid throws
          }
     }
}
