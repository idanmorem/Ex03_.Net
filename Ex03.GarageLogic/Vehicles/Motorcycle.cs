using System;
using System.Reflection;

namespace Ex03.GarageLogic
{
     public class Motorcycle : Vehicle
     {
          private eLicenseType m_LiscenceType;
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

          public eLicenseType LicenseType
          {
               get => m_LiscenceType;
               set => m_LiscenceType = value;
          }

          public override Type getUniqueType(string i_PropertyName)
          {
               Type specificType;
               if (i_PropertyName == "EngineSize")
               {
                    specificType = this.EngineSize.GetType();
               }
               else if (i_PropertyName == "LicenseType")
               {
                    specificType = typeof(Motorcycle.eLicenseType);
               }
               else
               {
                    throw new ArgumentException("BadType");
               }

               return specificType;
          }

          public override object AutonomicParser(PropertyInfo i_PropertyToBeParsed, object valueToBeParsed)
          {
               object parsedValue = null;
               string strValue = valueToBeParsed as string;
               //Wheel wheel in i_Vehicle.Wheels
               if (Equals(i_PropertyToBeParsed, this.GetType().GetProperty("EngineSize")))
               {
                    //TODO: check valid input
                    parsedValue = int.Parse(strValue);
               }
               else //it's the license type
               {
                    parsedValue = Enum.Parse(typeof(eLicenseType), strValue);
               }

               return parsedValue;
          }

          // public override string GetPropertyStrValue(PropertyInfo i_VehiclesUniqueProperty)
          // {
          //      throw new NotImplementedException();
          // }

          public enum eLicenseType
          {
               A,
               B1,
               AA,
               BB
          }
     }
}
