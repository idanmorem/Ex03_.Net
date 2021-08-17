namespace Ex03.GarageLogic
{
     class Truck : Vehicle
     {
          private float m_MaxLoad;
          private bool m_IsContainingDangerousMaterials;

          public Truck(string i_ModelName, string i_LiscenceNumber, Wheel.eNumberOfWheels i_NumberOfWheels, float i_MaxLoad, bool IsContainingDangerousMaterials) : base(i_ModelName, i_LiscenceNumber, Wheel.eNumberOfWheels.SixteenWheels)
          {

          }

          public float MaxLoad
          {
               get => m_MaxLoad;
               set
               {
                    if(value < 0)
                    {
                         throw new ValueOutOfRangeException();
                    }
                    else
                    {
                         m_MaxLoad = value;
                    }
               }
          }

          public bool IsContainingDangerousMaterials
          {
               get => m_IsContainingDangerousMaterials;
               set => m_IsContainingDangerousMaterials = value;
          }
     }
}
