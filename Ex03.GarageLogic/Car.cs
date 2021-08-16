

namespace Ex03.GarageLogic
{
     public class Car : Vehicle
     {
          private eColor m_Color;
          private eNumberOfDoors m_NumberOfDoors = eNumberOfDoors.FourDoors;
     }

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
