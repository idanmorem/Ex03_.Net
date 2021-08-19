using System;
using System.Collections.Generic;
using System.Reflection;

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

          public float GetMaxAirPressure(Vehicle i_Vehicle)
          {
               return i_Vehicle.Wheels[0].MaxAirPressure;
          }

          public void AddEngine(Vehicle i_Vehicle, Engine.eEngineType i_Type)
          {
               r_Factory.AddEngine(i_Vehicle, i_Type);
          }

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
               Vehicle currentVehicle;
               r_VehiclesInGarage.TryGetValue(i_ID, out currentVehicle);
               ((FuelEngine)currentVehicle.CurrentEngine).AddFuel(i_amountToFill, i_fuelType);
          }

          public void CheckIfVehicleExists(string i_input)
          {
               if (r_VehiclesInGarage.ContainsKey(i_input) == false)
               {
                    throw new KeyNotFoundException();
               }
          }

          public void CheckIfVehicleNotExists(string i_input)
          {
               if (r_VehiclesInGarage.ContainsKey(i_input) == true)
               {
                    throw new System.ArgumentException();
               }
          }

          public void AddWheels(Vehicle i_Vehicle, string i_ManufacturerName, float i_CurrentAirPressure)
          {
               foreach (Wheel wheel in i_Vehicle.Wheels)
               {
                    wheel.CurrentAirPressure = i_CurrentAirPressure;
                    wheel.ManufacturerName = i_ManufacturerName;
               }
          }

          public void AddSingleWheel(Vehicle i_Vehicle, string i_ManufacturerName, float i_CurrentAirPressure, int i_index)
          {
               i_Vehicle.Wheels[i_index].CurrentAirPressure = i_CurrentAirPressure;
               i_Vehicle.Wheels[i_index].ManufacturerName = i_ManufacturerName;
          }

          public float GetAmountOfEnergy(string i_ID)
          {
               Vehicle currentVehicle;
               r_VehiclesInGarage.TryGetValue(i_ID, out currentVehicle);
               return currentVehicle.CurrentEngine.GetAmountOfEnergy();
          }

          public float GetMaxAmoutOfEnergy(string i_ID)
          {
               Vehicle currentVehicle;
               r_VehiclesInGarage.TryGetValue(i_ID, out currentVehicle);
               return currentVehicle.CurrentEngine.GetMaxAmountOfEnergy();
          }

          public void CheckIfEngineIsFuel(string i_input)
          {
               Vehicle currentVehicle;
               r_VehiclesInGarage.TryGetValue(i_input, out currentVehicle);
               if (!(currentVehicle.CurrentEngine is FuelEngine))
               {
                    throw new System.ArgumentException();
               }
          }

          public void CheckIfFuelTypeIsCorrect(FuelEngine.eFuelType i_input, string i_ID)
          {
               Vehicle currentVehicle;
               r_VehiclesInGarage.TryGetValue(i_ID, out currentVehicle);
               if (i_input != (currentVehicle.CurrentEngine as FuelEngine).FuelType)
               {
                    throw new System.ArgumentException();
               }
          }

          public void CheckIfEngineIsElectric(string i_input)
          {
               Vehicle currentVehicle;
               r_VehiclesInGarage.TryGetValue(i_input, out currentVehicle);
               if (!(currentVehicle.CurrentEngine is ElectricEngine))
               {
                    throw new System.FormatException();
               }
          }

          //func no. 6
          public void Charge(string i_ID, float i_amountToFill)
          {
               Vehicle currentVehicle;
               r_VehiclesInGarage.TryGetValue(i_ID, out currentVehicle);
               ((ElectricEngine)currentVehicle.CurrentEngine).Charge(i_amountToFill);
          }

          //assumes the license plate nubmer is valid already
          public void ChangeStatus(string i_VehicleLicensePlate, Vehicle.eVehicleStatus i_NewStatus)
          {
               Vehicle currentVehicle = r_VehiclesInGarage[i_VehicleLicensePlate];
               currentVehicle.Status = i_NewStatus;
          }


          public Dictionary<string, Vehicle>.KeyCollection GetPlateList()
          {
               return r_VehiclesInGarage.Keys;
          }

          public Vehicle.eVehicleStatus getVehicleState(string i_VehicleLicensePlate)
          {
               Vehicle currentVehicle;
               r_VehiclesInGarage.TryGetValue(i_VehicleLicensePlate, out currentVehicle);
               return currentVehicle.Status;
          }

          //public VehicleDTOBundle GetVehicleBundle(string i_VehicleLicensePlate)
          //{
               //Vehicle currentVehicle;
               //r_VehiclesInGarage.TryGetValue(i_VehicleLicensePlate, out currentVehicle);
               //return new VehicleDTOBundle(currentVehicle, i_VehicleLicensePlate);
          //}

          public void FillWheelsAirPressure(string i_LicenseNumber)
          {
               Vehicle currentVehicle;
               r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out currentVehicle);
               foreach (Wheel wheel in r_VehiclesInGarage[i_LicenseNumber].Wheels)
               {
                    wheel.CurrentAirPressure = wheel.MaxAirPressure;
               }
          }

//           public class VehicleDTOBundle
//           {
//                private string m_LicenseNumber;

//                public string LicenseNumber
//                {
//                     get => m_LicenseNumber;
//                     set => m_LicenseNumber = value;
//                }

//                public Wheel[] Wheels
//                {
//                     get => m_Wheels;
//                     set => m_Wheels = value;
//                }

//                public Engine Engine
//                {
//                     get => engine;
//                     set => engine = value;
//                }

//                public VehicleDTOBundle()
//                {

//                }

//                private string m_Owners;

//                public string Owners
//                {
//                     get => m_Owners;
//                     set => m_Owners = value;
//                }

//                private Vehicle.eVehicleStatus m_Status;
//                public Vehicle.eVehicleStatus Status
//                {
//                     get => m_Status;
//                     set => m_Status = value;
//                }

//                private Wheel[] m_Wheels;

//                private Engine engine;

//                private string m_Model;
//                public string Model
//                {
//                     get { return m_Model; }
//                     set { m_Model = value; }
//                }


//                public VehicleDTOBundle(Vehicle i_Vehicle, string i_ID)
//                {
//                     //TODO: deep clone to move data safely

//                     this.LicenseNumber = i_ID;
//                     this.Model = i_Vehicle.ModelName;
//                     this.Owners = i_Vehicle.OwnersName;
//                     this.Status = i_Vehicle.Status;
//                     this.Wheels = i_Vehicle.Wheels;
//                     this.Engine = i_Vehicle.CurrentEngine;

//                }

//           }

          public void setValueForUniqueProperty(PropertyInfo i_UniquePropertyInfo, Vehicle i_NewVehicle, string i_NewPropertyValue)
          {

               i_UniquePropertyInfo.SetValue(i_NewVehicle, i_NewVehicle.AutonomicParser(i_UniquePropertyInfo, i_NewPropertyValue), null);
          }

          public List<PropertyInfo> GetVehiclesUniqueProperties(Vehicle i_NewVehicle)
          {
               PropertyInfo[] allProperties = i_NewVehicle.GetType().GetProperties();
               List<PropertyInfo> uniqueProperties = new List<PropertyInfo>();
               foreach (PropertyInfo currentCheckedProperty in allProperties)
               {
                    string checkedPropertyName = currentCheckedProperty.Name;

                    if (typeof(Vehicle).GetProperty(checkedPropertyName) == null) //if vehicle doesn't have this propery, it's unique.
                    {
                         uniqueProperties.Add(currentCheckedProperty);
                    }
               }

               return uniqueProperties;
          }
          
           public List<PropertyInfo> GetVehiclesUniqueProperties(string i_LicenseNumber)
        {
             GarageLogic.Vehicle copiedVehicle;
             if (r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out copiedVehicle) == false)
             {
                  throw new KeyNotFoundException();
             }
             return GetVehiclesUniqueProperties(r_VehiclesInGarage[i_LicenseNumber]);
        }

        public Vehicle getVehicleCopy(string i_ReadLine)
          {
               GarageLogic.Vehicle copiedVehicle;
               if (r_VehiclesInGarage.TryGetValue(i_ReadLine, out copiedVehicle) == false)
               {
                throw new KeyNotFoundException(); 
               }
               return copiedVehicle.DeepClone();
          }


        public string getStringPropertyValue(Vehicle i_ClonedVehicle, PropertyInfo i_VehiclesUniqueProperty)
        {
             return i_ClonedVehicle.AutonomicParser(i_VehiclesUniqueProperty, null) as string;
        }
     }
}
