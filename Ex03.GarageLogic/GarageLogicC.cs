using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class GarageLogicC
     {
          private readonly Dictionary<string, Vehicle> r_VehiclesInGarage;
          private readonly VehicleFactory r_Factory;

          public GarageLogicC()
          {
               r_VehiclesInGarage = new Dictionary<string, Vehicle>();
               r_Factory = new VehicleFactory();
          }

          public enum eGarageOperations
          {
               InsertNewVehicle = 1,
               ListLicencedVehicles,
               ChangeVehicleState,
               AddTirePressure,
               FillGasMotor,
               FillElectricMotor,
               ExhibitSpecificCar,
               QuitApp
          }

          public void AddVehicle(Vehicle i_Vehicle, string i_LicenseNumber)
          {
               r_VehiclesInGarage.Add(i_LicenseNumber, i_Vehicle);
          }

          public void AddEngine(Vehicle i_Vehicle, Engine.eEngineType i_Type)
          {
               r_Factory.AddEngine(i_Vehicle, i_Type);
          }

          //func no. 1
          public Vehicle CreateVehicle(Vehicle.eVehicleType i_Type)
          {
               return r_Factory.CreateVehicle(i_Type);
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