namespace Ex03.GarageLogic
{
     class Truck : Vehicle
     {
          private float m_MaxLoad;
          private bool m_IsContainingDangerousMaterials;

          public Truck() : base(Wheel.eNumberOfWheels.SixteenWheels) { }

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
