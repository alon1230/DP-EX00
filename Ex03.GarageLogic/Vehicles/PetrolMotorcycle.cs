using Ex03.GarageLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Interfaces.IPetrolUser;

namespace Ex03.GarageLogic
{
    class PetrolMotorcycle: Motorcycle,IPetrolUser
    {
        const float k_TankSize = 6f;
        const eFuelType k_FuelType = eFuelType.Octan96;


        public PetrolMotorcycle(int i_EngineVol, eLicenseType i_licenseType, string i_ModelName, string i_LicenseNumber,
            float i_EnergyLevel, float i_AirPressure, string i_TyreManufacturer = "") : base(i_EngineVol, i_licenseType, i_ModelName, i_LicenseNumber, i_EnergyLevel)
        {
            this.CreateTyreList(k_NumOfTyres, i_TyreManufacturer, i_AirPressure, k_MaxAirPressure);
            this.m_Engine = new PetrolEngine(k_FuelType, k_TankSize * (i_EnergyLevel / 100), k_TankSize);
        }
        public void ChargeEngine(float i_Fuel,eFuelType i_FuelType)
        {
            (this.m_Engine as PetrolEngine).ChargeEngine(i_Fuel, i_FuelType);

        }
        



    }
}
