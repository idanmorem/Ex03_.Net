using System;
using System.Reflection;

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

          public override Type getUniqueType(string i_PropertyName)
          {
               Type specificType;
               if (i_PropertyName == "Color")
               {
                    specificType = typeof(Car.eCarColor);
               }
               else if (i_PropertyName == "NumberOfDoors")
               {
                    specificType = typeof(Car.eNumberOfDoors);
               }
               else
               {
                    throw new ArgumentException("BadType"); //change
               }

               return specificType;
          }

          public override object AutonomicParser(PropertyInfo i_PropertyToBeParsed, object valueToBeParsed)
          {
               object parsedValue = null;
               string strValue = valueToBeParsed as string;
               //Wheel wheel in i_Vehicle.Wheels
               if (Equals(i_PropertyToBeParsed, this.GetType().GetProperty("Color")))
               {
                    //TODO: check valid input
                    parsedValue = Enum.Parse(typeof(eCarColor), strValue);
               }
               else //it's the number of doors
               {
                    parsedValue = Enum.Parse(typeof(eNumberOfDoors), strValue);
               }

               return parsedValue;
          }
     }
}
