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

     }

     public enum eFuelType
     {
          Soler,
          Octan95,
          Octan96,
          Octan98
     }
}
