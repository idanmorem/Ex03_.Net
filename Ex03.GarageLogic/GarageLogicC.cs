using System.Collections.Generic;

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

          //TODO: updated - new
          public void AddPrecentage(Vehicle i_Vehicle, float i_input)
          {
               i_Vehicle.CurrentEngine.EnergyPercent = i_input;
               i_Vehicle.CurrentEngine.CalcCurrentEnergy();
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

          public Dictionary<string, Vehicle>.KeyCollection GetPlateList()
          {
               return r_VehiclesInGarage.Keys;
          }

          public Vehicle.eVehicleStatus getVehicleState(string i_VehicleLicencePlate)
          {
               return r_VehiclesInGarage[i_VehicleLicencePlate].Status;
          }

          public VehicleDTOBundle GetVehicleBundle(string i_LicenseNumber)
          {
              return new VehicleDTOBundle(r_VehiclesInGarage[i_LicenseNumber]);
          }

          public class VehicleDTOBundle
          {
               public Wheel[] Wheels
               {
                    get => m_Wheels;
                    set => m_Wheels = value;
               }

               public Engine Engine
               {
                    get => engine;
                    set => engine = value;
               }

               public VehicleDTOBundle()
               {
   
               }

               private string m_Owners;

               public string Owners
               {
                    get => m_Owners;
                    set => m_Owners = value;
               }

               private Vehicle.eVehicleStatus m_Status;
            public Vehicle.eVehicleStatus Status
               {
                    get => m_Status;
                    set => m_Status = value;
               }


            private Wheel[] m_Wheels;

            private Engine engine;
   



            private string m_Model;
            public string Model
               {
                get { return m_Model; }
                set { m_Model = value; }
               }


               public VehicleDTOBundle(Vehicle i_Vehicle)
               {
                    //TODO: deep clone to move data safely
                    

                    this.Model = i_Vehicle.ModelName;
                    this.Owners = i_Vehicle.OwnersName;
                    this.Status = i_Vehicle.Status;
                    this.Wheels = i_Vehicle.Wheels;
                    this.Engine = i_Vehicle.CurrentEngine;

               }

               public override string ToString()
               {
                    return "Model: " + Model + "\nOwners: " + Owners + "\nState: " + Status + "\nWheels: " + "TODO" +
                           "\nEngine: " + "TODO";
                    
               }
          }

          
        //
        // public class WheelsDTO
        // {
        //      public float AirPreasure
        //      {
        //           get => m_AirPreasure;
        //           set => m_AirPreasure = value;
        //      }
        //
        //      public string Manufacturer
        //      {
        //           get => m_Manufacturer;
        //           set => m_Manufacturer = value;
        //      }
        //
        //      private float m_AirPreasure;
        //      private string m_Manufacturer;
        // }
        //
        // public struct EngineDTO
        // {
        //      public FuelEngine.eFuelType FuelType
        //      {
        //           get => fuelType;
        //           set => fuelType = value;
        //      }
        //
        //      public float BatteryState
        //      {
        //           get => batteryState;
        //           set => batteryState = value;
        //      }
        //
        //      private FuelEngine.eFuelType fuelType;
        //      private float batteryState;
        // }

        //TODO: add UniqueDTO
    }
}

    