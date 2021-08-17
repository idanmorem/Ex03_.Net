using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     class Truck : Vehicle
     {
          private float m_MaxLoad;
          private bool m_IsContainingDangerousMaterials;

          public Truck(string i_LiscenceNumber, Wheel.eNumberOfWheels i_NumberOfWheels, float i_MaxLoad, bool IsContainingDangerousMaterials) : base(i_LiscenceNumber, i_NumberOfWheels)
          {
               try
               {
                    if (i_MaxLoad >= 0)
                    {
                         m_MaxLoad = i_MaxLoad;
                    }
               }
               catch (ValueOutOfRangeException i_ValueOutOfRangeException)
               {
                    Console.WriteLine("Catching ValueOutOfRangeException:");

               }
          }

          public float MaxLoad
          {
               get => m_MaxLoad;
               set => m_MaxLoad = value;
          }

          public bool IsContainingDangerousMaterials
          {
               get => m_IsContainingDangerousMaterials;
               set => m_IsContainingDangerousMaterials = value;
          }
     }
}
