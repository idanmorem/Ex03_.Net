namespace Ex03.GarageLogic
{
     public abstract class Engine
     {
          private float m_EnergyPercent;

          public float EnergyPercent
          {
               get => m_EnergyPercent;
               set
               {
                    m_EnergyPercent = value;
               }
          }

          public abstract float CalcEnergyPercent();

          //TODO: updated - new
          public abstract void CalcCurrentEnergy();


          public enum eEngineType
          {
               Fuel,
               Electric
          }       
     }
}