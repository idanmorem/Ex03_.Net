namespace Ex03.GarageLogic
{
     public class ElectricEngine : Engine
     {
          private float m_BatteryTimeLeft;
          private float m_MaxBatteryTime;

          private void charge(float i_AmountOfTimeToAdd)
          {
               //...
          }

          public ElectricEngine(float i_BatteryTimeLeft, float i_MaxBatteryTime)
          {

          }


          public float BatteryTimeLeft
          {
               get => m_BatteryTimeLeft;
               set => m_BatteryTimeLeft = value;
          }

          public float MaxBatteryTime
          {
               get => m_MaxBatteryTime;
               set => m_MaxBatteryTime = value;
          }
     }
}
