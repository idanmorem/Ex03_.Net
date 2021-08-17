using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
               try
               {
                    if(i_BatteryTimeLeft <= i_MaxBatteryTime && i_BatteryTimeLeft >= 0 && i_MaxBatteryTime >= 0)
                    {
                         BatteryTimeLeft = i_BatteryTimeLeft;
                         MaxBatteryTime = i_MaxBatteryTime;
                    }
               }
               catch (ValueOutOfRangeException i_ValueOutOfRangeException)
               {
                    Console.WriteLine("Catching ValueOutOfRangeException:");

               }
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
