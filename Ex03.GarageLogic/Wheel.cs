namespace Ex03.GarageLogic
{
     public class Wheel
     {
          private string m_ManufacturerName;
          private float m_CurrentAirPressure;
          private float m_MaxAirPressure;

          public Wheel (string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
          {
               try
               {
                    if (i_CurrentAirPressure <= i_MaxAirPressure && i_CurrentAirPressure >= 0 && i_MaxAirPressure >= 0)
                    {
                         CurrentAirPressure = i_CurrentAirPressure;
                         ManufacturerName = i_ManufacturerName;
                         MaxAirPressure = i_MaxAirPressure;
                    }
               }
               catch (ValueOutOfRangeException i_ValueOutOfRangeException)
               {
                    Console.WriteLine("Catching ValueOutOfRangeException:");

               }
          }

          private void AddAir(float i_AmountOfAirToAdd)
          {
               //...
          }

          public string ManufacturerName
          {
               get => m_ManufacturerName;
               set => m_ManufacturerName = value;
          }

          public float CurrentAirPressure
          {
               get => m_CurrentAirPressure;
               set => m_CurrentAirPressure = value;
          }

          public float MaxAirPressure
          {
               get => m_MaxAirPressure;
               set => m_MaxAirPressure = value;
          }

          public enum eNumberOfWheels
          {
               TwoWheels = 2,
               FourWheels = 4,
               SixteenWheels = 16
          }
     }
}
