using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class ConsoleUi
    {
        private GarageLogic.GarageLogic m_GarageLogic;
        public static void Main()
        {
            ConsoleUi ui = new ConsoleUi();
            ui.GarageMenu();
        }

        public ConsoleUi()
        {
            m_GarageLogic = new GarageLogic.GarageLogic();
        }
        public void GarageMenu()
        {
            bool contBrowsingMenu = true;
            while (contBrowsingMenu)
            {
                try
                {
                    GarageLogic.GarageLogic.eGarageOperations currentOperation;
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

        private bool getInputForAction(GarageLogic.GarageLogic.eGarageOperations i_GetCurrentOperation)
        {
            bool contStatus = true;
             if (i_GetCurrentOperation == GarageLogic.GarageLogic.eGarageOperations.InsertNewVehicle)
             {
                 insertNewVehicleUserConsoleInput();
             }
             else if (i_GetCurrentOperation == GarageLogic.GarageLogic.eGarageOperations.ListLicencedVehicles)
             {
                 getListLicencedVehiclesConsoleInput();
             }
             else if (i_GetCurrentOperation == GarageLogic.GarageLogic.eGarageOperations.ChangeVehicleState)
             {
                 getChangeVehicleStateConsoleInput();
             }
             else if (i_GetCurrentOperation == GarageLogic.GarageLogic.eGarageOperations.AddTirePressure)
             {
                 getAddTirePressureInput();
             }
             else if (i_GetCurrentOperation == GarageLogic.GarageLogic.eGarageOperations.FillGasMotor)
             {
                 getFillGasMotorInput();
             }
             else if (i_GetCurrentOperation == GarageLogic.GarageLogic.eGarageOperations.FillElectricMotor)
             {
                 getFillElectricMotorInput();
             }
             else if (i_GetCurrentOperation == GarageLogic.GarageLogic.eGarageOperations.ExhibitSpecificCar)
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

        private void getFillElectricMotorInput()
        {
            throw new NotImplementedException();
        }

        private void getFillGasMotorInput()
        {
            throw new NotImplementedException();
        }

        private void getAddTirePressureInput()
        {
            throw new NotImplementedException();
        }

        private void getChangeVehicleStateConsoleInput()
        {
            throw new NotImplementedException();
        }

        private void getListLicencedVehiclesConsoleInput()
        {
            throw new NotImplementedException();
        }

        private void insertNewVehicleUserConsoleInput()
        {
      
            //  m_GarageLogic.getAvailableVehicles(); //TODO-Hard: this function, which returns a string of available vehicles, can also create on UI
            Console.WriteLine("Hello! Please choose a vehicle to add to the garage by the matching numbers, followed by an ENTER.");

            //theres a function Enum.getName() but only available since FrameWork 5 OR 6 and also bad for modularity.
            //should print vehicle names

            string vehicleType = Console.ReadLine();
            checkValidVehicleInput();
            //if valid => parse to int => enum
            m_GarageLogic.createVehicle(/*parsed enum*/); //TODO-Hard: this, which doesn't throw exception


        }


        private GarageLogic.GarageLogic.eGarageOperations getCurrentOperation(string i_CurrentUserInput)
        {
            int userChoice;
            GarageLogic.GarageLogic.eGarageOperations currentOperation;
            userChoice = int.Parse(i_CurrentUserInput);
            //TODO: check valid input (1-8) throws FormatERxceptions
            return (GarageLogic.GarageLogic.eGarageOperations)userChoice;
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
            Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}", k_InsertNewCar, k_ExhibitLicencedPlates, k_ChangeState, k_AddTirePressure, k_FillGas, k_ChargeElectric, k_ExhibitSingle, K_Quit);

        }
    }

    
}
