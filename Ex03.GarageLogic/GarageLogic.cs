using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class GarageLogic
     {
          private readonly Dictionary<string, Vehicle> r_VehiclesInGarage;

          public GarageLogic()
          {
               r_VehiclesInGarage = new Dictionary<string, Vehicle>();
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

          //func no. 5
          public void AddFuel(string i_ID, FuelEngine.eFuelType i_fuelType, float i_amountToFill)
          {
               if (r_VehiclesInGarage.ContainsKey(i_ID))
               {
                    Vehicle currentVehicle;
                    r_VehiclesInGarage.TryGetValue(i_ID, out currentVehicle);
                    if (currentVehicle.CurrentEngine is FuelEngine)
                    {
                         ((FuelEngine)currentVehicle.CurrentEngine).AddFuel(i_amountToFill, i_fuelType);
                    }
                    else
                    {
                         throw new System.FormatException();
                    }
               }
               else
               {
                    throw new ValueOutOfRangeException();
               }
          }

          //func no. 6
          public void Charge(string i_ID, float i_amountToFill)
          {
               if (r_VehiclesInGarage.ContainsKey(i_ID))
               {
                    Vehicle currentVehicle;
                    r_VehiclesInGarage.TryGetValue(i_ID, out currentVehicle);
                    if (currentVehicle.CurrentEngine is ElectricEngine)
                    {
                         ((ElectricEngine)currentVehicle.CurrentEngine).Charge(i_amountToFill);
                    }
                    else
                    {
                         throw new System.FormatException();
                    }
               }
               else
               {
                    throw new ValueOutOfRangeException();
               }
          }

          //func no. 3
          public void ChangeStatus(string i_ID, Vehicle.eVehicleStatus i_NewStatus)
          {
               if (r_VehiclesInGarage.ContainsKey(i_ID))
               {
                    Vehicle currentVehicle;
                    r_VehiclesInGarage.TryGetValue(i_ID, out currentVehicle);
                    currentVehicle.Status = i_NewStatus;
               }
               else
               {
                    throw new ValueOutOfRangeException();
               }
          }
     }
}