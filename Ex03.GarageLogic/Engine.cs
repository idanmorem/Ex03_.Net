namespace Ex03.GarageLogic
{
     public abstract class Engine
     {
          private float m_EnergyPercent;

          public float EnergyPercent
          {
               get => m_EnergyPercent;
          }

          public abstract float CalcEnergyPercent();
     }
}