using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
     public class ConsoleUi
     {
          private GarageLogic.GarageLogicC m_GarageLogic;
          private string lastActionMessage = null; //array of messages-> expandable 

          public static void Main()
          {
               ConsoleUi ui = new ConsoleUi();
               ui.GarageMenu();
          }

          public ConsoleUi()
          {
               m_GarageLogic = new GarageLogic.GarageLogicC();
          }

          public void GarageMenu()
          {

            Console.WriteLine("Salutations!~");

            createTestVehicles(); //for tests ONLY
               bool contBrowsingMenu = true;
               while (contBrowsingMenu)
               {
                    try
                    {
                         Console.Clear();
                         if (lastActionMessage != null)
                         {
                              Console.WriteLine(lastActionMessage);
                         }

                         printMainMenu();
                         string currentUserInput = Console.ReadLine();
                         contBrowsingMenu = getInputForAction(getCurrentOperation(currentUserInput));
                    }
                    catch (KeyNotFoundException e)
                    {
                         lastActionMessage = "ERROR: The entered license plate does not exist in our garage!\n";
                    }
                    catch (Exception e)
                    {
                         lastActionMessage = e.Message;
                    }
               }
               Console.WriteLine("You've chosen to quit, goodbye!~");
          }

          private bool getInputForAction(GarageLogic.GarageLogicC.eGarageOperations i_GetCurrentOperation)
          {
               bool contStatus = true;
               if (i_GetCurrentOperation == GarageLogic.GarageLogicC.eGarageOperations.InsertNewVehicle)
               {
                    insertNewVehicleUserConsoleInput();
               }
               else if (i_GetCurrentOperation == GarageLogic.GarageLogicC.eGarageOperations.ListLicencedVehicles)
               {
                    getListLicencedVehiclesToConsole();
               }
               else if (i_GetCurrentOperation == GarageLogic.GarageLogicC.eGarageOperations.ChangeVehicleState)
               {
                    ChangeVehicleStateConsoleInput();
               }
               else if (i_GetCurrentOperation == GarageLogic.GarageLogicC.eGarageOperations.AddTirePressure)
               {
                    addTirePressureInput();
               }
               else if (i_GetCurrentOperation == GarageLogic.GarageLogicC.eGarageOperations.FillGasMotor)
               {
                    FillGasMotor();
               }
               else if (i_GetCurrentOperation == GarageLogic.GarageLogicC.eGarageOperations.FillElectricMotor)
               {
                    FillElectricMotorInput();
               }
               else if (i_GetCurrentOperation == GarageLogic.GarageLogicC.eGarageOperations.ExhibitSpecificCar)
               {
                    ExhibitSpecificCarToConsole();
               }
               else //quit
               {
                    contStatus = false;
               }

               return contStatus;
          }

        private void ExhibitSpecificCarToConsole()
        {
             string licensePlateNumber;
            Console.WriteLine("Sup, here you can enter a vehicles license's plate and get tons of data on the vehicle!" +
                              " how cool is that???");
            Console.WriteLine("Enter a license plate of a vehicle within our garage, if the vehicle isn't found here, you'll be informed correspondingly.");
            Vehicle clonedVehicle = m_GarageLogic.getVehicleCopy(licensePlateNumber = Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            sb.Append("License Number: ");
            sb.Append(licensePlateNumber);
            sb.Append("\nModel: ");
            sb.Append(clonedVehicle.ModelName);
            sb.Append("\nOwners: ");
            sb.Append(clonedVehicle.OwnersName);
            sb.Append("\nStatus: ");
            sb.Append(clonedVehicle.Status);
            int wheelIndex = 0;
            foreach (Wheel wheel in clonedVehicle.Wheels)
            {
                sb.Append("\n\nWheel number: ");
                sb.Append(wheelIndex);
                sb.Append("\nWheels manufecturer: ");
                sb.Append(clonedVehicle.Wheels[wheelIndex].ManufacturerName);
                sb.Append("\nWheels Pressure: ");
                sb.Append(clonedVehicle.Wheels[wheelIndex].CurrentAirPressure);
                wheelIndex++;
            }

            if (clonedVehicle.CurrentEngine is FuelEngine)
            {
                sb.Append("\nEngine fuel precentage is: ");
                sb.Append(clonedVehicle.CurrentEngine.EnergyPercent);
                sb.Append("\nEngine fuel type is: ");
                sb.Append((clonedVehicle.CurrentEngine as FuelEngine).FuelType.ToString());
            }
            else if (clonedVehicle.CurrentEngine is ElectricEngine)
            {
                sb.Append("\nEngine battery precentage is: ");
                sb.Append(clonedVehicle.CurrentEngine.EnergyPercent);
            }

            foreach (PropertyInfo vehiclesUniqueProperty in m_GarageLogic.GetVehiclesUniqueProperties(licensePlateNumber))
            {
                 sb.Append("\n " + vehiclesUniqueProperty.Name + ": " + m_GarageLogic.getStringPropertyValue(clonedVehicle, vehiclesUniqueProperty)); //TODO: get the generically
            }
            sb.Append("\n");
            lastActionMessage = sb.ToString();
        }

        private void FillElectricMotorInput()
          {
               Console.WriteLine("Hello! Please enter the license number, followed by an ENTER.");
               string LicenseNumber = Console.ReadLine();
               m_GarageLogic.CheckIfVehicleExists(LicenseNumber);
               m_GarageLogic.CheckIfEngineIsElectric(LicenseNumber);
               Console.WriteLine("The current amount of battery hours left is {0} out of {1}", m_GarageLogic.GetAmountOfEnergy(LicenseNumber), m_GarageLogic.GetMaxAmoutOfEnergy(LicenseNumber));
               Console.WriteLine("Hello! Please choose the amount of hours to fill, followed by an ENTER.");
               string amountToFill = Console.ReadLine();
               m_GarageLogic.Charge(LicenseNumber, float.Parse(amountToFill));
               lastActionMessage = "Success - the vehicle hours of battery left has been updated\n";
          }

          private void FillGasMotor()
          {
               Console.WriteLine("Hello! Please enter the license number, followed by an ENTER.");
               string LicenseNumber = Console.ReadLine();
               m_GarageLogic.CheckIfVehicleExists(LicenseNumber);
               m_GarageLogic.CheckIfEngineIsFuel(LicenseNumber);
               Console.WriteLine("Please choose a fuel type for the vehicle, followed by an ENTER.");
               int i = 0;
               foreach (FuelEngine.eFuelType Type in Enum.GetValues(typeof(FuelEngine.eFuelType)))
               {
                    Console.WriteLine("Press {0} to insert a {1}", i, Type.ToString());
                    ++i;
               }
               string newFuelType = Console.ReadLine();
               m_GarageLogic.CheckIfFuelTypeIsCorrect((FuelEngine.eFuelType)Enum.Parse(typeof(FuelEngine.eFuelType), newFuelType), LicenseNumber);
               Console.WriteLine("The current amount of fuel is {0} out of {1}", m_GarageLogic.GetAmountOfEnergy(LicenseNumber), m_GarageLogic.GetMaxAmoutOfEnergy(LicenseNumber));
               Console.WriteLine("Please choose the amount of fuel to fill, followed by an ENTER.");
               string amountToFill = Console.ReadLine();
               m_GarageLogic.AddFuel(LicenseNumber, (FuelEngine.eFuelType)Enum.Parse(typeof(FuelEngine.eFuelType), newFuelType), float.Parse(amountToFill));
               lastActionMessage = "Success - the vehicle fuel amount has been updated\n";
          }

          private void addTirePressureInput()
          {
               Console.WriteLine("Here you can fill a vehicle's tires to it's maximum capacity");

               Console.WriteLine("If you dont want to fill air, press 1, followed by an enter");
               Console.WriteLine("Otherwise, Please enter the license number, followed by an ENTER.");

               string userChoice = Console.ReadLine();

               if (userChoice == "1")
               {
                    lastActionMessage = "Action successfully canceled.\n";
               }
               else
               {
                    m_GarageLogic.FillWheelsAirPressure(userChoice);
                    lastActionMessage = "Success - The wheel's pressure is maximum\n";
               }
          }

          private void ChangeVehicleStateConsoleInput()
          {
               Console.WriteLine("Here you can change your vehicles state in the garage.");
               Console.WriteLine("Please enter the license number, followed by an ENTER.");
               string LicenseNumber = Console.ReadLine();
               m_GarageLogic.CheckIfVehicleExists(LicenseNumber);
      
               int i = 0;
               foreach (Vehicle.eVehicleStatus Status in Enum.GetValues(typeof(Vehicle.eVehicleStatus)))
               {
                    Console.WriteLine("Press {0} to change the vehicle status to {1}", i, Status.ToString());
                    ++i;
               }
               string NewStatus = Console.ReadLine();
               m_GarageLogic.ChangeStatus(LicenseNumber, (Vehicle.eVehicleStatus)Enum.Parse(typeof(Vehicle.eVehicleStatus), NewStatus));
               lastActionMessage = "The vehicle has succesfully changed his status\n";
          }

          private void getListLicencedVehiclesToConsole()
          {
               StringBuilder sb = new StringBuilder();
               int counter = 1;
               Console.WriteLine("Here you can view a list of all the vehicles our lovely garage. ");
               Console.WriteLine("The list consists of the plate-numbers and their current-states");
               Console.WriteLine("if you wish the view the plate numbers only, press 1, otherwise, press any other key.");
               if (Console.ReadLine() == "1")
               {
                    sb.Append("List Format: Plate Number\n\n");
                    foreach (string vehicleLicencePlate in m_GarageLogic.GetPlateList())
                    {
                         sb.Append(counter);
                         sb.Append(". PlateNumber: ");
                         sb.Append(vehicleLicencePlate);
                         sb.Append("\n");
                         ++counter;
                    }
               }
               else
               {
                    Console.WriteLine("Hello! Please choose the car status you wish to display:");
                    int i = 0;
                    foreach(Vehicle.eVehicleStatus status in Enum.GetValues(typeof(Vehicle.eVehicleStatus)))
                    {
                         Console.WriteLine("Press {0} to display status {1}", i, status.ToString());
                         i++;
                    }
                    string VehicleStatus = Console.ReadLine();
                    sb.Append("List Format: Plate Number\n\n");
                    foreach (string vehicleLicencePlate in m_GarageLogic.GetPlateList())
                    {
                         if (((int)(m_GarageLogic.getVehicleState(vehicleLicencePlate))) == int.Parse(VehicleStatus))
                         {
                              sb.Append(counter);
                              sb.Append(". PlateNumber:");
                              sb.Append(vehicleLicencePlate);
                              sb.Append("\n");
                              ++counter;
                         }
                    }
                    if(counter == 1)
                    {
                         sb.Append("Nothing to display\n");
                    }
               }
               lastActionMessage = sb.ToString();
          }

          private void insertNewVehicleUserConsoleInput()
          {
               Console.WriteLine("Hello! Please choose a vehicle to add to the garage by the matching numbers, followed by an ENTER.");
               int i = 0;
               foreach (Vehicle.eVehicleType Type in Enum.GetValues(typeof(Vehicle.eVehicleType)))
               {
                    Console.WriteLine("Press {0} to insert a {1}", i, Type.ToString());
                    ++i;
               }
               string vehicleType = Console.ReadLine();
               checkValidVehicleTypeInput(vehicleType);
               Vehicle newVehicle = m_GarageLogic.CreateVehicle((Vehicle.eVehicleType)Enum.Parse(typeof(Vehicle.eVehicleType), vehicleType));

               Console.WriteLine("Hello! Please enter the model name, followed by an ENTER.");
               string ModelName = Console.ReadLine();
               newVehicle.ModelName = ModelName;

               Console.WriteLine("Hello! Please enter the license number, followed by an ENTER.");
               string LicenseNumber = Console.ReadLine();
               checkValidLicenseNumberInput(LicenseNumber);
               m_GarageLogic.CheckIfVehicleNotExists(LicenseNumber);
               //TODO: check if there isn't already a vehicle with the same LicenseNumber     

               Console.WriteLine("Hello! Please enter the owner name, followed by an ENTER.");
               string OwnerName = Console.ReadLine();
               newVehicle.OwnersName = OwnerName;

               Console.WriteLine("Hello! Please enter the owner number, followed by an ENTER.");
               string PhoneNumber = Console.ReadLine();
               checkValidPhoneNumberInput(PhoneNumber);
               newVehicle.OwnersPhoneNumber = PhoneNumber;

               Console.WriteLine("Hello! Please choose an engine type for your vehicle, followed by an ENTER.");
               i = 0;
               foreach (Engine.eEngineType Type in Enum.GetValues(typeof(Engine.eEngineType)))
               {
                    Console.WriteLine("Press {0} to insert a {1}", i, Type.ToString());
                    ++i;
               }
               string EngineType = Console.ReadLine();
               checkValidEngineTypeInput(EngineType);
               m_GarageLogic.AddEngine(newVehicle, (Engine.eEngineType)Enum.Parse(typeof(Engine.eEngineType), EngineType));

               Console.WriteLine("Hello! Please enter the precentage of energy left in the Vehicle, followed by an ENTER.");
               string energyPrecentage = Console.ReadLine();
               checkValidEnergyPrecentageeInput(energyPrecentage);
               m_GarageLogic.AddPrecentage(newVehicle, float.Parse(energyPrecentage));


               //TODO: duplicating code
               Console.WriteLine("Hello! Welcome to the wheels section\nif you want to enter the same information for all wheels please press 1, otherwise press any other key.");
               string WheelManufacturerName;
               string CurrentAirPressure;
               if (Console.ReadLine() == "1")
               {
                    wheelInput(newVehicle, out WheelManufacturerName, out CurrentAirPressure);     
                    m_GarageLogic.AddWheels(newVehicle, WheelManufacturerName, float.Parse(CurrentAirPressure));
               }
               else
               {
                    int wheelIndex = 0;
                    foreach(Wheel wheel in newVehicle.Wheels)
                    {
                         Console.WriteLine("Here you will enter information for wheel number {0}:", wheelIndex + 1);
                         wheelInput(newVehicle, out WheelManufacturerName, out CurrentAirPressure);
                         m_GarageLogic.AddSingleWheel(newVehicle, WheelManufacturerName, float.Parse(CurrentAirPressure), wheelIndex);
                         wheelIndex++;
                    }
               }

               specialConditions(newVehicle);

               //i try so hard
               //in the end it doesn't ever matter
               m_GarageLogic.AddVehicle(newVehicle, LicenseNumber);
               lastActionMessage = "The vehicle has been succesfully added to the data base\n";
        }

          private void wheelInput(Vehicle i_Vehicle, out string i_ManufecturerName, out string i_CurrentAirPressure)
          {
               Console.WriteLine("Hello! Please enter the Wheel manufacturer name, followed by an ENTER.");
               i_ManufecturerName = Console.ReadLine();
               Console.WriteLine("Hello! The Wheel's maximum air pressure is: {0}", m_GarageLogic.GetMaxAirPressure(i_Vehicle));
               Console.WriteLine("Hello! Please enter the Wheels current air pressure, followed by an ENTER.");
               i_CurrentAirPressure  = Console.ReadLine();
               checkValidCurrentAirPressureInput(i_CurrentAirPressure);
          }

          private void specialConditions(Vehicle i_NewVehicle)
          {

               foreach (PropertyInfo uniquePropertyInfo in m_GarageLogic.GetVehiclesUniqueProperties(i_NewVehicle))
               {

                    //prints required data

                    string newPropertyValue;

                    if (uniquePropertyInfo.PropertyType.BaseType == typeof(Enum))
                    {
                         newPropertyValue = handleEnumCase(i_NewVehicle, uniquePropertyInfo);
                    }
                    else if (uniquePropertyInfo.PropertyType == typeof(bool))
                    {
                         newPropertyValue = handleBooleanCase(i_NewVehicle, uniquePropertyInfo);
                    }
                    else
                    {
                         newPropertyValue = handleSingleInputCase(i_NewVehicle, uniquePropertyInfo);
                    }



                    m_GarageLogic.setValueForUniqueProperty(uniquePropertyInfo, i_NewVehicle, newPropertyValue);
               }

          }

          private string handleBooleanCase(Vehicle i_NewVehicle, PropertyInfo i_UniquePropertyInfo)
          {
               Console.WriteLine("Choosing " + i_UniquePropertyInfo.Name + ":");
               Console.WriteLine("Press 1 if true or 2 if false");
               return Console.ReadLine();
          }

          //works for int, string, float, double
          //does not work for boolean
          //does not work for Point(int x, int y)
          private string handleSingleInputCase(Vehicle i_NewVehicle, PropertyInfo i_UniquePropertyInfo)
          {
               Console.WriteLine("Enter the desired " + i_UniquePropertyInfo.Name + ":");
               return Console.ReadLine();
          }

          private string handleEnumCase(Vehicle i_NewVehicle, PropertyInfo i_UniquePropertyInfo)
          {
               Type matchingTypeEnum = i_NewVehicle.getUniqueType(i_UniquePropertyInfo.Name);
               Console.WriteLine("Choosing " + i_UniquePropertyInfo.Name + ":");
               getEnumConsoleMessage(matchingTypeEnum);

               //user enters enum choice
               return Console.ReadLine();
               //TODO: check input
               //returns the input for the settergu
          }

          private void getEnumConsoleMessage(Type i_MatchingTypeEnum)
          {
               int i = 0;
               foreach (Enum enumType in Enum.GetValues(i_MatchingTypeEnum))
               {
                    Console.WriteLine("Press " + i + " to pick a " + enumType.ToString());
                    ++i;
               }
          }

          private void checkValidCurrentAirPressureInput(string i_input)
          {
               if (float.Parse(i_input) < 0)
               {
                    throw new ValueOutOfRangeException();
               }
          }

          private void checkValidVehicleTypeInput(string i_input)
          {
               if (int.Parse(i_input) > typeof(Vehicle.eVehicleType).GetEnumValues().Length || int.Parse(i_input) < 0)
               {
                    throw new ValueOutOfRangeException();
               }
          }

          private void checkValidLicenseNumberInput(string i_input)
          {
               if (int.Parse(i_input) <= 0)
               {
                    throw new ValueOutOfRangeException();
               }
          }

          private void checkValidPhoneNumberInput(string i_input)
          {
               if (int.Parse(i_input) <= 0)
               {
                    throw new ValueOutOfRangeException();
               }
          }

          private void checkValidEngineTypeInput(string i_input)
          {
               if (int.Parse(i_input) > typeof(Engine.eEngineType).GetEnumValues().Length || int.Parse(i_input) < 0)
               {
                    throw new ValueOutOfRangeException();
               }
          }

          private void checkValidEnergyPrecentageeInput(string i_input)
          {
               if (float.Parse(i_input) > 100 || float.Parse(i_input) < 0)
               {
                    throw new ValueOutOfRangeException();
               }
          }

          private GarageLogic.GarageLogicC.eGarageOperations getCurrentOperation(string i_CurrentUserInput)
          {
               int userChoice;
               userChoice = int.Parse(i_CurrentUserInput);
               //TODO: check valid input (1-8) throws FormatERxceptions
               return (GarageLogic.GarageLogicC.eGarageOperations)userChoice;
          }

          private void printMainMenu()
          {
               const string k_InsertNewCar = "Press 1 to ENTER A NEW VEHICLE into the garage";
               const string k_ExhibitLicencedPlates = "Press 2 to LIST ALL VEHICLES that are licenced in our garage.";
               const string k_ChangeState = "Press 3 to CHANGE a vehicles PROGRESS STATE.";
               const string k_AddTirePressure = "Press 4 to ADD TIRE PRESSURE.";
               const string k_FillGas = "Press 5 to FILL GAS to a gasoline-based engine vehicle.";
               const string k_ChargeElectric = "Press 6 to CHARGE an ELECTRIC-based engine vehicle";
               const string k_ExhibitSingle = "Press 7 to EXHIBIT a VEHICLE.";
               const string K_Quit = "Press 8 to end our services.";

               Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n", k_InsertNewCar, k_ExhibitLicencedPlates, k_ChangeState, k_AddTirePressure, k_FillGas, k_ChargeElectric, k_ExhibitSingle, K_Quit);
          }

          private void createTestVehicles()
          {
               Vehicle firstCar = m_GarageLogic.CreateVehicle(Vehicle.eVehicleType.Car);
               firstCar.ModelName = "Ferari x-325";
               firstCar.OwnersName = "Tikva";
               firstCar.OwnersPhoneNumber = "1111111111";
               m_GarageLogic.AddEngine(firstCar, Engine.eEngineType.Fuel);
               firstCar.CurrentEngine.EnergyPercent = 50;
               firstCar.CurrentEngine.CalcCurrentEnergy();
               foreach (var wheel in firstCar.Wheels)
               {
                    wheel.CurrentAirPressure = 10;
                    wheel.ManufacturerName = "2KOOL4SKOOL";
               }



               Vehicle secondCar = m_GarageLogic.CreateVehicle(Vehicle.eVehicleType.Car);
               secondCar.ModelName = "Mitsubishi-Attrage";
               secondCar.OwnersName = "Menash";
               secondCar.OwnersPhoneNumber = "2222222222";
               m_GarageLogic.AddEngine(secondCar, Engine.eEngineType.Electric);
               secondCar.CurrentEngine.EnergyPercent = 20;
               secondCar.CurrentEngine.CalcCurrentEnergy();
               foreach (var wheel in secondCar.Wheels)
               {
                    wheel.CurrentAirPressure = 15;
                    wheel.ManufacturerName = "2KOOL5SKOOL";
               }


            Vehicle firstMotorCycle = m_GarageLogic.CreateVehicle(Vehicle.eVehicleType.Motorcycle);
               firstMotorCycle.ModelName = "Honda-NemesisXG";
               firstMotorCycle.OwnersName = "Nahum";
               firstMotorCycle.OwnersPhoneNumber = "3333333333";
               m_GarageLogic.AddEngine(firstMotorCycle, Engine.eEngineType.Fuel);
               secondCar.CurrentEngine.EnergyPercent = 30;
            foreach (var wheel in firstMotorCycle.Wheels)
               {
                    wheel.CurrentAirPressure = 20;
                    wheel.ManufacturerName = "2KOOL6SKOOL";
               }
               

            Vehicle firstTruck = m_GarageLogic.CreateVehicle(Vehicle.eVehicleType.Truck);
            firstTruck.ModelName = "BigMoma";
            firstTruck.OwnersName = "AlsoABigMoma";
            firstTruck.OwnersPhoneNumber = "1234";
            m_GarageLogic.AddEngine(firstTruck, Engine.eEngineType.Fuel);
            secondCar.CurrentEngine.EnergyPercent = 40;
            foreach (var wheel in firstTruck.Wheels)
            {
                 wheel.CurrentAirPressure = 25;
                 wheel.ManufacturerName = "2KOOL7SKOOL";
            }

            m_GarageLogic.AddVehicle(firstCar, "11111");
               m_GarageLogic.AddVehicle(secondCar, "80085");
               m_GarageLogic.AddVehicle(firstMotorCycle, "22222");
               m_GarageLogic.AddVehicle(firstTruck, "33333");
        }
     }
}