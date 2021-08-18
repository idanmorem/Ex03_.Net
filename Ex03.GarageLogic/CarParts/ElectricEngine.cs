namespace Ex03.GarageLogic
{
     public class ElectricEngine : Engine
     {
          private float m_BatteryTimeLeft;
          private float m_MaxBatteryTime;

          public void Charge(float i_AmountOfTimeToAdd)
          {
               BatteryTimeLeft = m_BatteryTimeLeft + i_AmountOfTimeToAdd;
          }

          public override float CalcEnergyPercent()
          {
               return ((m_BatteryTimeLeft / m_MaxBatteryTime) * 100);
          }

          //TODO: updated - new
          public override void CalcCurrentEnergy()
          {
               m_BatteryTimeLeft = ((m_MaxBatteryTime * base.EnergyPercent) / 100);
          }

          public override float GetAmountOfEnergy()
          {
               return BatteryTimeLeft;
          }

          public override float GetMaxAmountOfEnergy()
          {
               return MaxBatteryTime;
          }
          public float BatteryTimeLeft
          {
               get => m_BatteryTimeLeft;
               set
               {
                    if (value < m_BatteryTimeLeft)
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
                         base.EnergyPercent = CalcEnergyPercent();
                    }
               }
          }

          public float MaxBatteryTime
          {
               get => m_MaxBatteryTime;
               set
               {
                    if (value < 0)
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
