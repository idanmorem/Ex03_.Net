namespace Ex03.GarageLogic
{
     public abstract class Vehicle
     {
          private string m_ModelName;
          private readonly string r_LiscenceNumber;
          private float m_EnergyPercent;
          private Wheel m_Wheels; // array of Wheels
          private readonly Wheel.eNumberOfWheels r_NumberOfWheels;
          private string m_OwnersName;
          private string m_OwnersPhoneNumber;
          private eVehicleStatus m_Status;
          private Engine m_Engine;

          public enum eVehicleStatus
          {
               InProgress,
               Fixed,
               Paid
          }

          //this isn't good because if a tractor is added this needs to be updated aswell.
          //maybe switch with model
          public enum eVehicleType
          {
               Car,
               MotorCycle,
               Truck,
               Tractor
          }
    }
}
