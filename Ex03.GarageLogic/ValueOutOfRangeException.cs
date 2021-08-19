namespace Ex03.GarageLogic
{
     public class ValueOutOfRangeException : System.Exception
     {
          private float m_MaxValue;

          public float MaxValue
          {
               get => m_MaxValue;
               set => m_MaxValue = value;
          }

          public float MinValue
          {
               get => m_MinValue;
               set => m_MinValue = value;
          }

          private float m_MinValue;
     }
}
