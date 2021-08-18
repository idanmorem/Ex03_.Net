namespace Ex03.GarageLogic
{
     public class FuelEngine : Engine
     {
          private eFuelType m_FuelType;
          private float m_CurrentFuelAmount;
          private float m_MaxFuelAmount;

          public void AddFuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
          {
               if(i_FuelType == m_FuelType) // checking if same fuel type
               {

                    CurrentFuelAmount = m_CurrentFuelAmount + i_AmountOfFuelToAdd;
               }
               else
               {
                    throw new System.ArgumentException();
               }
          }

          public override float CalcEnergyPercent()
          {
               return ((m_CurrentFuelAmount / m_MaxFuelAmount) * 100);
          }

          //TODO: updated - new
          public override void CalcCurrentEnergy()
          {
               m_CurrentFuelAmount = ((m_MaxFuelAmount * base.EnergyPercent) / 100);
          }

          public FuelEngine()
          {

          }

          public eFuelType FuelType
          {
               get => m_FuelType;
               set
               {
                    if(value == m_FuelType)
                         m_FuelType = value;
               }
          }

          public float CurrentFuelAmount
          {
               get => m_CurrentFuelAmount;
               set
               {
                    if (value < m_CurrentFuelAmount)
                    {
                         throw new ValueOutOfRangeException();
                    }
                    else if (value > m_MaxFuelAmount)
                    {
                         throw new System.ArgumentException();
                    }
                    else
                    {
                         m_CurrentFuelAmount = value;
                    }               
               }
          }


          public float MaxFuelAmount
          {
               get => m_MaxFuelAmount;
               set
               {
                    if(value < 0)
                    {
                         throw new ValueOutOfRangeException();
                    }
                    else if(value < m_CurrentFuelAmount)
                    {
                         throw new System.ArgumentException();
                    }
                    else
                    {
                         m_MaxFuelAmount = value;
                    }
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
}
