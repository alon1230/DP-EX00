using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Interfaces;
using static Ex03.GarageLogic.Interfaces.IPetrolUser;

namespace Ex03.GarageLogic
{
    class PetrolCar : Car, IPetrolUser
    {
        const float k_TankSize = 45f;
        const eFuelType k_FuelType = eFuelType.Octan98;

        public PetrolCar(eColor i_Color, int i_Doors, string i_ModelName, string i_LicenseNumber, float i_EnergyLevel, float i_AirPressure, string i_TyreManufacturer = "") : base(i_Color, i_Doors, i_ModelName, i_LicenseNumber, i_EnergyLevel)
        {
            this.m_Engine = new PetrolEngine(k_FuelType, k_TankSize * (i_EnergyLevel / 100), k_TankSize);
            this.CreateTyreList(k_NumOfTyres, i_TyreManufacturer, i_AirPressure, k_MaxAirPressure);
        }

        public void ChargeEngine(float i_Fuel, eFuelType i_FuelType)
        {
            (this.m_Engine as PetrolEngine).ChargeEngine(i_Fuel, i_FuelType);
        }
    }
}
