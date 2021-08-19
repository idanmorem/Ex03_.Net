namespace Ex03.GarageLogic
{
     public class ValueOutOfRangeException : System.Exception
     {
          private float m_MaxValue;
          private float m_MinValue;

        public ValueOutOfRangeException(string message, float i_MaxValue, float i_MinValue) : base(message)
          {
               MaxValue = i_MaxValue;
               MinValue = i_MinValue;
          }

          public ValueOutOfRangeException()
          {
          }

          public ValueOutOfRangeException(string message, float i_MinValue)
          {
               MinValue = i_MinValue;
          }

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

     }
}
