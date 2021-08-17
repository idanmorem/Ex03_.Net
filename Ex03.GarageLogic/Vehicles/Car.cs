namespace Ex03.GarageLogic
{
     public class Car : Vehicle
     {
          private eCarColor m_Color;
          private eNumberOfDoors m_NumberOfDoors = eNumberOfDoors.FourDoors;

          public Car() : base(Wheel.eNumberOfWheels.FourWheels) { }

          public eCarColor Color
          {
               get => m_Color;
               set => m_Color = value;
          }

          public eNumberOfDoors NumberOfDoors
          {
               get => m_NumberOfDoors;
               set
               {
                    if (value <= eNumberOfDoors.FiveDoors && value >= eNumberOfDoors.TwoDoors)
                    {
                         m_NumberOfDoors = value;
                    }
                    else
                    {
                         throw new ValueOutOfRangeException();
                    }
               }
          }

          public enum eCarColor
          {
               Red,
               Silver,
               White,
               Black
          }

          public enum eNumberOfDoors
          {
               TwoDoors = 2,
               ThreeDoors,
               FourDoors,
               FiveDoors
          }
     }
}
