namespace Ex03.GarageLogic
{
     public abstract class Vehicle
     {
          private string m_ModelName;
          private Wheel[] m_Wheels; // TODO: set the wheels
          private readonly Wheel.eNumberOfWheels r_NumberOfWheels;
          private string m_OwnersName;
          private string m_OwnersPhoneNumber;
          private eVehicleStatus m_Status;
          private Engine m_CurrentEngine;

          public Vehicle(Wheel.eNumberOfWheels i_NumberOfWheels)
          {
               m_Status = eVehicleStatus.InProgress;
               r_NumberOfWheels = i_NumberOfWheels;
               m_Wheels = new Wheel[(int)i_NumberOfWheels];
               for(int i = 0; i < (int)i_NumberOfWheels; i++)
               {
                    m_Wheels[i] = new Wheel();
               }
          }

          public enum eVehicleStatus
          {
               InProgress,
               Fixed,
               Paid
          }

          public Wheel[] Wheels
          {
               get => m_Wheels;
          }

          public string ModelName
          {
               get => m_ModelName;
               set => m_ModelName = value;
          }

          public Wheel.eNumberOfWheels NumberOfWheels
          {
               get => r_NumberOfWheels;
          }

          public string OwnersName
          {
               get => m_OwnersName;
               set => m_OwnersName = value;
          }

          public string OwnersPhoneNumber
          {
               get => m_OwnersPhoneNumber;
               set => m_OwnersPhoneNumber = value;
          }

          public eVehicleStatus Status
          {
               get => m_Status;
               set => m_Status = value;
          }

          public Engine CurrentEngine
          {
               get => m_CurrentEngine;
               set => m_CurrentEngine = value;
          }

          public enum eVehicleType
          {
               Car,
               Motorcycle,
               Truck
          }
     }
}
