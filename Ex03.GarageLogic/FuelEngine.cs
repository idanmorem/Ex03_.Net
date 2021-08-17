using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
               try
               {
                    if (i_CurrentFuelAmount <= i_MaxFuelAmount && i_CurrentFuelAmount >= 0 && i_MaxFuelAmount >= 0)
                    {
                         CurrentFuelAmount = i_CurrentFuelAmount;
                         MaxFuelAmount = i_MaxFuelAmount;
                         FuelType = i_FuelType;
                    }
               }
               catch (ValueOutOfRangeException i_ValueOutOfRangeException)
               {
                    Console.WriteLine("Catching ValueOutOfRangeException:");

               }
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
