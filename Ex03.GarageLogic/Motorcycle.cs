namespace Ex03.GarageLogic
{
     public class Motorcycle : Vehicle
     {
          private eLiscenceType m_LiscenceType;
          private int m_EngineSize;

          public Motorcycle(string i_ModelName, string i_LiscenceNumber, Wheel.eNumberOfWheels i_NumberOfWheels, eLiscenceType i_LiscenceType, int i_EngineSize) : base(i_ModelName, i_LiscenceNumber, i_NumberOfWheels)
          {

          }

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
