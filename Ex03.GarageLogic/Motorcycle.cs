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
     }

     public enum eLiscenceType
     {
          A,
          B1,
          AA,
          BB
     }
}
