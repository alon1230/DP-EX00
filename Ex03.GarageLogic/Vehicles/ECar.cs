using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Interfaces;

namespace Ex03.GarageLogic
{
    class ECar : Car,IElectricUser
    {
        const float k_MaxEngineTime = 3.2f;
       

        public ECar(eColor i_Color, int i_Doors, string i_ModelName, string i_LicenseNumber, float i_EnergyLevel, float i_AirPressure, string i_TyreManufacturer = "") : base(i_Color, i_Doors, i_ModelName, i_LicenseNumber, i_EnergyLevel)
        {
            this.m_Engine = new Engine(k_MaxEngineTime * (i_EnergyLevel / 100), k_MaxEngineTime);
            this.CreateTyreList(k_NumOfTyres, i_TyreManufacturer, i_AirPressure, k_MaxAirPressure);
        }

        public void ChargeEngine(float i_Time, Action updateEnergylevel)
        {
            this.m_Engine.ChargeEngine(i_Time, updateEnergylevel);
        }
    }
}
