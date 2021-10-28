using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Tyre
    {
        string m_Manufacturer;
        float m_AirPressure;
        float m_MaxAirPressure;

        public Tyre(string i_Manufacturer, float i_AirPressure, float i_MaxAirPressure)
        {
            this.m_Manufacturer = i_Manufacturer;
            this.m_AirPressure = i_AirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
        }
           
        public void FillAir(float i_Air)
        {
            if (this.m_AirPressure + i_Air <= m_MaxAirPressure)
            {
                this.m_AirPressure += i_Air;
            }
            else
            {
                throw new ValueOutOfRangeException("Filling air exceeded max air pressure");
            }

        }
    }
}
