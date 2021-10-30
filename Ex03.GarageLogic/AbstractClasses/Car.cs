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
                throw new ValueOutOfRangeException(2,5,$"Number of doors: {i_Doors} is not on the range of 2 to 5");
            }
            this.m_Doors = i_Doors;
        }
        public override StringBuilder GetFullDetails(string i_FormatString, StringBuilder io_stringBuilder = null)
        {
            io_stringBuilder = base.GetFullDetails(i_FormatString, io_stringBuilder);
            io_stringBuilder.AppendFormat(i_FormatString, "Number of Doors", m_Doors);
            io_stringBuilder.AppendFormat(i_FormatString, "color", m_Color);
            return io_stringBuilder;

        }
    }
}
