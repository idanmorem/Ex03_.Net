namespace Ex03.GarageLogic
{
     public class Motorcycle : Vehicle
     {
          private eLiscenceType m_LiscenceType;
          private int m_EngineSize;

          public Motorcycle() : base(Wheel.eNumberOfWheels.TwoWheels) { }


          public int EngineSize
          {
               get => m_EngineSize;
               set
               {
                    if(value <= 0)
                    {
                         throw new ValueOutOfRangeException();
                    }
                    else
                    {
                         m_EngineSize = value;
                    }
               }
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
