using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Interfaces;
namespace Ex03.GarageLogic
{
    class EMotorcycle : Motorcycle, IElectricUser
    {
        float k_MaxEngineTime = 1.8f;
        

        public EMotorcycle(int i_EngineVol, eLicenseType i_licenseType, string i_ModelName, string i_LicenseNumber,
            float i_EnergyLevel, float i_AirPressure, string i_TyreManufacturer = "") :base(i_EngineVol, i_licenseType, i_ModelName, i_LicenseNumber,
            i_EnergyLevel)
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
