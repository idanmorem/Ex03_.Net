namespace Ex03.GarageLogic
{
     public abstract class Vehicle
     {
          private string m_ModelName;
          private readonly string r_LiscenceNumber;
          private float m_EnergyPercent;
          private Wheel[] m_Wheels; // TODO: set the wheels
          private readonly Wheel.eNumberOfWheels r_NumberOfWheels;
          private string m_OwnersName;
          private string m_OwnersPhoneNumber;
          private eVehicleStatus m_Status;
          private Engine m_CurrentEngine;

          public Vehicle(string i_LiscenceNumber, Wheel.eNumberOfWheels i_NumberOfWheels)
          {

               r_LiscenceNumber = i_LiscenceNumber;
               r_NumberOfWheels = i_NumberOfWheels;
               m_Wheels = new Wheel[(int)i_NumberOfWheels];
          }

          public enum eVehicleStatus
          {
               InProgress,
               Fixed,
               Paid
          }

          public string ModelName
          {
               get => m_ModelName;
               set => m_ModelName = value;
          }

          public string LiscenceNumber
          {
               get => r_LiscenceNumber;
          }

          public float EnergyPercent
          {
               get => m_EnergyPercent;
               set => m_EnergyPercent = value;
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
     }
}
