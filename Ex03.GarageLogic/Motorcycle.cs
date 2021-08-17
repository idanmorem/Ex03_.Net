using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public class Motorcycle : Vehicle
     {
          private eLiscenceType m_LiscenceType;
          private int m_EngineSize;

          public Motorcycle(string i_LiscenceNumber, Wheel.eNumberOfWheels i_NumberOfWheels, eLiscenceType i_LiscenceType, int i_EngineSize) : base(i_LiscenceNumber, i_NumberOfWheels)
          {
               try
               {
                    if (i_EngineSize >= 0)
                    {
                         EngineSize = i_EngineSize;
                         LiscenceType = i_LiscenceType;
                    }
               }
               catch (ValueOutOfRangeException i_ValueOutOfRangeException)
               {
                    Console.WriteLine("Catching ValueOutOfRangeException:");

               }
          }

          public int EngineSize
          {
               get => m_EngineSize;
               set => m_EngineSize = value;
          }

          public eLiscenceType LiscenceType
          {
               get => m_LiscenceType;
               set => m_LiscenceType = value;
          }
     }

     public enum eLiscenceType
     {
          A,
          B1,
          AA,
          BB
     }
}
