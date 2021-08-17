namespace Ex03.GarageLogic
{
     public class ElectricEngine : Engine
     {
          private float m_BatteryTimeLeft;
          private float m_MaxBatteryTime;

          private void charge(float i_AmountOfTimeToAdd)
          {
               if ((m_BatteryTimeLeft + i_AmountOfTimeToAdd) <= m_MaxBatteryTime)
               {
                    m_BatteryTimeLeft = m_BatteryTimeLeft + i_AmountOfTimeToAdd;
               }
               else
               {
                    throw new ValueOutOfRangeException();
               }
          }

          public override float CalcEnergyPercent()
          {
               return ((m_BatteryTimeLeft / m_MaxBatteryTime) * 100);
          }

          public float BatteryTimeLeft
          {
               get => m_BatteryTimeLeft;
               set
               {
                    if (value < 0)
                    {
                         throw new ValueOutOfRangeException();
                    }
                    else if (value > m_MaxBatteryTime)
                    {
                         throw new System.ArgumentException();
                    }
                    else
                    {
                         m_BatteryTimeLeft = value;
                    }
               }
          }

          public float MaxBatteryTime
          {
               get => m_MaxBatteryTime;
               set
               {
                    if(value < 0)
                    {
                         throw new ValueOutOfRangeException();
                    }
                    else if (value < m_BatteryTimeLeft)
                    {
                         throw new System.ArgumentException();
                    }
                    else
                    {
                         m_MaxBatteryTime = value;
                    }
               }
          }
     }
}
