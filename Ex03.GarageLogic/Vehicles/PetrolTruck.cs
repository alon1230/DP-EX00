using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Interfaces;
using static Ex03.GarageLogic.Interfaces.IPetrolUser;

namespace Ex03.GarageLogic
{
    class PetrolTruck : Vehicle, IPetrolUser
    {
        const float k_TankSize = 115f;
        const eFuelType k_FuelType = eFuelType.Octan96;
        protected const int k_NumOfTyres = 12;
        protected const float k_MaxAirPressure = 28f;

        bool m_DangerousSubstances;
        float m_MaxLoad;

        public PetrolTruck(string i_ModelName, string i_LicenseNumber, float i_EnergyLevel, float i_MaxLoad, bool i_DangerousSubstances,
            float i_AirPressure, string i_TyreManufacturer = "") : base(i_ModelName, i_LicenseNumber, i_EnergyLevel)
        {
            this.m_DangerousSubstances = i_DangerousSubstances;
            this.m_MaxLoad = i_MaxLoad;
            this.m_Engine = new PetrolEngine(k_FuelType, k_TankSize * (i_EnergyLevel / 100), k_TankSize);
            this.CreateTyreList(k_NumOfTyres, i_TyreManufacturer, i_AirPressure, k_MaxAirPressure);
        }

        public void ChargeEngine(float i_Fuel, eFuelType i_FuelType, Action updateEnergylevel)
        {
            (this.m_Engine as PetrolEngine).ChargeEngine(i_Fuel, i_FuelType, updateEnergylevel);
        }
        public override StringBuilder GetFullDetails(string i_FormatString, StringBuilder io_stringBuilder = null)
        {
            io_stringBuilder = base.GetFullDetails(i_FormatString, io_stringBuilder);
            io_stringBuilder.AppendFormat(i_FormatString, "Max load", m_MaxLoad);
            io_stringBuilder.AppendFormat(i_FormatString, "Carry Dangerous Substances", m_DangerousSubstances);
            return io_stringBuilder;

        }
    }
}
