using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car: Vehicle
    {
        protected const int k_NumOfTyres = 4;
        protected const float k_MaxAirPressure = 32f;
        public enum eColor
        {
            grey,
            blue,
            white,
            black
        }

        protected eColor m_Color;
        protected int m_Doors;

        protected Car(eColor i_Color,int i_Doors, string i_ModelName, string i_LicenseNumber, float i_EnergyLevel) : base(i_ModelName, i_LicenseNumber, i_EnergyLevel)
        {
            this.m_Color = i_Color;
            if (i_Doors<2 || i_Doors > 5)
            {
                throw new ValueOutOfRangeException(string.Format("Number of doors: {0} is not on the range of 2 to 5",i_Doors));
            }
            this.m_Doors = i_Doors;
        }
    }
}
