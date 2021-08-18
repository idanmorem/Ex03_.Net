using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
     public class ConsoleUi
     {
          private GarageLogic.GarageLogicC m_GarageLogic;
          private string[] lastActionMessages; //array of messages-> expandable 

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

               createTestVehicles(); //for tests ONLY
               bool contBrowsingMenu = true;
               while (contBrowsingMenu)
               {
                    try
                    {
                         GarageLogic.GarageLogicC.eGarageOperations currentOperation;
                         printMainMenu();
                         string currentUserInput = Console.ReadLine();
                         contBrowsingMenu = getInputForAction(getCurrentOperation(currentUserInput));

                    }
                    catch (Exception e)
                    {
                         Console.WriteLine(e.Message);
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
                    getAddTirePressureInput();
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
               Console.WriteLine("Sup, here you can enter a vehicles license's plate and get tons of data on the vehicle!" +
                                 " how cool is that???");
               Console.WriteLine("Enter a license plate of a vehicle within our garage, if the vehicle isn't found here, you'll be informed correspondingly.");
               GarageLogicC.VehicleDTOBundle bundle = m_GarageLogic.GetVehicleBundle(Console.ReadLine());
               Console.WriteLine(bundle.ToString());
               //TODO: better model: "Model: {0}| Owners: {1}| Vehicle state in garage: {2}| TODO wheels...{3}| TODO engine print{4}", Model, Owners,Status, "TODO: Print Wheels", "TODO: Print Engine";
          }

          //TODO: updated - changed location of checks
          private void FillElectricMotorInput()
          {
               Console.WriteLine("Hello! Please enter the license number, followed by an ENTER.");
               string LicenseNumber = Console.ReadLine();
               m_GarageLogic.CheckIfVehicleExists(LicenseNumber);
               m_GarageLogic.CheckIfEngineIsElectric(LicenseNumber);
               //TODO: present the current amount of energy
               Console.WriteLine("Hello! Please choose the amount of hours to fill, followed by an ENTER.");
               string amountToFill = Console.ReadLine();
               m_GarageLogic.Charge(LicenseNumber, float.Parse(amountToFill));
          }


          //TODO: updated - changed location of checks
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
               Console.WriteLine("Please choose the amount of fuel to fill, followed by an ENTER.");
               string amountToFill = Console.ReadLine();
               m_GarageLogic.AddFuel(LicenseNumber, (FuelEngine.eFuelType)Enum.Parse(typeof(FuelEngine.eFuelType), newFuelType), float.Parse(amountToFill));
          }



          private void getAddTirePressureInput(string i_LicenseNumber)
          {
            Console.WriteLine("Here you can fill a vehicle's tires to it's maximum capacity");
            


            Console.WriteLine("If you dont want to fill air, press 1, followed by an enter");
            Console.WriteLine("Otherwise, Please enter the license number, followed by an ENTER.");

            if ("1" == Console.ReadLine())
            {
                 Console.WriteLine("Action successfully canceled.");
            }
            else
            {
                 m_GarageLogic.FillWheelsAirPressure(i_LicenseNumber);
                 Console.WriteLine("Action successful.");
            }
          }

          private void ChangeVehicleStateConsoleInput()
          {
               Console.WriteLine("Here you can change your vehicles state in the garage.");
               Console.WriteLine("Please enter the license number, followed by an ENTER.");
               string LicenseNumber = Console.ReadLine();
               //check validation
               int i = 0;
               foreach (Vehicle.eVehicleStatus Status in Enum.GetValues(typeof(Vehicle.eVehicleStatus)))
               {
                    Console.WriteLine("Press {0} to change the vehicle status to {1}", i, Status.ToString());
                    ++i;
               }
               string NewStatus = Console.ReadLine();
               m_GarageLogic.ChangeStatus(LicenseNumber, (Vehicle.eVehicleStatus)Enum.Parse(typeof(Vehicle.eVehicleStatus), NewStatus));

          }

          private void getListLicencedVehiclesToConsole()
          {
               int counter = 1;
               Console.WriteLine("Here you can view a list of all the vehicles our lovely garage. ");
               Console.WriteLine("The list consists of the plate-numbers and their current-states");
               Console.WriteLine("if you wish the view the plate numbers only, press 1, otherwise, press any other key.");
               if (Console.ReadLine() == "1")
               {
                    Console.WriteLine("List Format: Plate Number");
                    foreach (string vehicleLicencePlate in m_GarageLogic.GetPlateList())
                    {
                         Console.WriteLine("{0}. PlateNumber: {1}", counter, vehicleLicencePlate);
                         ++counter;
                    }
               }
               else
               {
                    Console.WriteLine("List Format: Plate Number | State");
                    foreach (string vehicleLicencePlate in m_GarageLogic.GetPlateList())
                    {
                         Console.WriteLine("{0}. PlateNumber: {1} | State: {2}", counter, vehicleLicencePlate,
                             m_GarageLogic.getVehicleState(vehicleLicencePlate));
                         ++counter;
                    }
               }
          }

          //TODO: updated - added validation check function calls
          private void insertNewVehicleUserConsoleInput()
          {

               //  m_GarageLogic.getAvailableVehicles(); //TODO-Hard: this function, which returns a string of available vehicles, can also create on UI
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

               Console.WriteLine("Hello! Please enter the precentage of energy left in the Vehicle, followed by an ENTER.");
               string EnergyPrecentage = Console.ReadLine();
               checkValidEnergyPrecentageeInput(EnergyPrecentage);
               m_GarageLogic.AddPrecentage(newVehicle, float.Parse(EnergyPrecentage));

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

               //TODO: add specialCondition method(Car-Doors, Motorcycle-License type) - DAN

               //TODO: ask for wheels

               //in the end
               m_GarageLogic.AddVehicle(newVehicle, LicenseNumber);
          }

          private void checkValidVehicleTypeInput(string i_input)
          {
               if (int.Parse(i_input) > typeof(Vehicle.eVehicleType).GetEnumValues().Length || int.Parse(i_input) < 0)
               {
                    throw new ValueOutOfRangeException();
               }
          }

          //TODO: updated - new
          private void checkValidLicenseNumberInput(string i_input)
          {
               if (int.Parse(i_input) <= 0)
               {
                    throw new ValueOutOfRangeException();
               }
          }

          //TODO: updated - new
          private void checkValidPhoneNumberInput(string i_input)
          {
               if (int.Parse(i_input) <= 0)
               {
                    throw new ValueOutOfRangeException();
               }
          }

          //TODO: updated - new
          private void checkValidEngineTypeInput(string i_input)
          {
               if (int.Parse(i_input) > typeof(Engine.eEngineType).GetEnumValues().Length || int.Parse(i_input) < 0)
               {
                    throw new ValueOutOfRangeException();
               }
          }

          //TODO: updated - new
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
               GarageLogic.GarageLogicC.eGarageOperations currentOperation;
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

               Console.WriteLine("Salutations!~");
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

               Vehicle secondCar = m_GarageLogic.CreateVehicle(Vehicle.eVehicleType.Car);
               secondCar.ModelName = "Mitsubishi-Attrage";
               secondCar.OwnersName = "Menash";
               secondCar.OwnersPhoneNumber = "2222222222";
               m_GarageLogic.AddEngine(secondCar, Engine.eEngineType.Electric);
               secondCar.CurrentEngine.EnergyPercent = 20;
               secondCar.CurrentEngine.CalcCurrentEnergy();
         
               Vehicle firstMotorCycle = m_GarageLogic.CreateVehicle(Vehicle.eVehicleType.Motorcycle);
               firstMotorCycle.ModelName = "Honda-NemesisXG";
               firstMotorCycle.OwnersName = "Nahum";
               firstMotorCycle.OwnersPhoneNumber = "3333333333";
               m_GarageLogic.AddEngine(firstMotorCycle, Engine.eEngineType.Fuel);

               m_GarageLogic.AddVehicle(firstCar, "LN11111");
               m_GarageLogic.AddVehicle(secondCar, "800854LIFE");
               m_GarageLogic.AddVehicle(firstMotorCycle, "RAKBB");
          }
     }
}