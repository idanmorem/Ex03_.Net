namespace Ex03.GarageLogic
{
     public class Car : Vehicle
     {
          private eColor m_Color;
          private eNumberOfDoors m_NumberOfDoors = eNumberOfDoors.FourDoors;

          public Car (string i_LiscenceNumber, Wheel.eNumberOfWheels i_NumberOfWheels, eColor i_Color, eNumberOfDoors i_NumberOfDoors) : base(i_LiscenceNumber, i_NumberOfWheels)
          {
               Color = i_Color;
               NumberOfDoors = i_NumberOfDoors;
          }

          public eColor Color
          {
               get => m_Color;
               set => m_Color = value;
          }

          public eNumberOfDoors NumberOfDoors
          {
               get => m_NumberOfDoors;
               set => m_NumberOfDoors = value;
          }
     }

     //TODO: here or inside the class?
     public enum eColor
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
