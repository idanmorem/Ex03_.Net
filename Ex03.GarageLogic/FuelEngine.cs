namespace Ex03.GarageLogic
{
     public class FuelEngine : Engine
     {
          private eFuelType m_FuelType;
          private float m_CurrentFuelAmount;
          private float m_MaxFuelAmount;

          private void AddFuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
          {
               //...
          }

          public FuelEngine(eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount)
          {

          }

          public abstract float CalcEnergyPercent // overriding the base
          {
               return (m_CurrentFuelAmount / m_MaxFuelAmount) * 100;
          }

          public eFuelType FuelType
          {
               get => m_FuelType;
               set => m_FuelType = value;
          }

          public float CurrentFuelAmount
          {
               get => m_CurrentFuelAmount;
               set => m_CurrentFuelAmount = value;
          }


          public float MaxFuelAmount
          {
               get => m_MaxFuelAmount;
               set => m_MaxFuelAmount = value;
          }
     }

     public enum eFuelType
     {
          Soler,
          Octan95,
          Octan96,
          Octan98
     }
}
