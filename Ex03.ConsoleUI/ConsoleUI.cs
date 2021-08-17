﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
     public class ConsoleUi
     {
          private GarageLogic.GarageLogicC m_GarageLogic;

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
                    getListLicencedVehiclesConsoleInput();
               }
               else if (i_GetCurrentOperation == GarageLogic.GarageLogicC.eGarageOperations.ChangeVehicleState)
               {
                    getChangeVehicleStateConsoleInput();
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
                    getExhibitSpecificCarInput();
               }
               else //quit
               {
                    contStatus = false;
               }

               return contStatus;
          }

          private void getExhibitSpecificCarInput()
          {
               throw new NotImplementedException();
          }

          private void FillElectricMotorInput()
          {
               Console.WriteLine("Hello! Please enter the license number, followed by an ENTER.");
               string LicenseNumber = Console.ReadLine();
               Console.WriteLine("Hello! Please choose the amount of hours to fill, followed by an ENTER.");
               string amountToFill = Console.ReadLine();
               //check validity
               m_GarageLogic.Charge(LicenseNumber, float.Parse(amountToFill));
          }

          private void FillGasMotor()
          {
               Console.WriteLine("Hello! Please enter the license number, followed by an ENTER.");
               string LicenseNumber = Console.ReadLine();
               Console.WriteLine("Hello! Please choose a fuel type for the vehicle, followed by an ENTER.");
               int i = 0;
               foreach (FuelEngine.eFuelType Type in Enum.GetValues(typeof(FuelEngine.eFuelType)))
               {
                    Console.WriteLine("Press {0} to insert a {1}", i, Type.ToString());
                    ++i;
               }
               string newFuelType = Console.ReadLine();
               //check validity
               Console.WriteLine("Hello! Please choose the amount of fuel to fill, followed by an ENTER.");
               string amountToFill = Console.ReadLine();
               //check validity
               m_GarageLogic.AddFuel(LicenseNumber, (FuelEngine.eFuelType)Enum.Parse(typeof(FuelEngine.eFuelType), newFuelType), float.Parse(amountToFill));
          }

          private void getAddTirePressureInput()
          {
               throw new NotImplementedException();
          }

          private void getChangeVehicleStateConsoleInput()
          {
               Console.WriteLine("Hello! Please enter the license number, followed by an ENTER.");
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

          private void getListLicencedVehiclesConsoleInput()
          {
               throw new NotImplementedException();
          }

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
               checkValidVehicleInput(vehicleType);
               Vehicle newVehicle = m_GarageLogic.CreateVehicle((Vehicle.eVehicleType)Enum.Parse(typeof(Vehicle.eVehicleType), vehicleType));
               
               Console.WriteLine("Hello! Please enter the model name, followed by an ENTER.");
               string ModelName = Console.ReadLine();
               //check validation
               newVehicle.ModelName = ModelName;
               
               Console.WriteLine("Hello! Please enter the license number, followed by an ENTER.");
               string LicenseNumber = Console.ReadLine();
               //check validation
               
               Console.WriteLine("Hello! Please enter the owner name, followed by an ENTER.");
               string OwnerName = Console.ReadLine();
               //check validation
               newVehicle.OwnersName = OwnerName;
               
               Console.WriteLine("Hello! Please enter the owner number, followed by an ENTER.");
               string PhoneNumber = Console.ReadLine();
               //check validation
               newVehicle.OwnersPhoneNumber = PhoneNumber;

               Console.WriteLine("Hello! Please choose an engine, followed by an ENTER.");
               i = 0;
               foreach (Engine.eEngineType Type in Enum.GetValues(typeof(Engine.eEngineType)))
               {
                    Console.WriteLine("Press {0} to insert a {1}", i, Type.ToString());
                    ++i;
               }
               string EngineType = Console.ReadLine();
               //check validation
               m_GarageLogic.AddEngine(newVehicle, (Engine.eEngineType)Enum.Parse(typeof(Engine.eEngineType), EngineType));

               //in the end
               m_GarageLogic.AddVehicle(newVehicle, LicenseNumber);
          }

          private void checkValidVehicleInput(string i_input)
          {
               if (int.Parse(i_input) > typeof(Vehicle.eVehicleType).GetEnumValues().Length || int.Parse(i_input) < 0)
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
     }


}
