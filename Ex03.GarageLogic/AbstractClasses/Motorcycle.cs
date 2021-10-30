    using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected const int k_NumOfTyres = 2;
        protected const float k_MaxAirPressure = 30f;
        public enum eLicenseType
        {
            A,
            A1,
            B1,
            B2

        }
        eLicenseType m_LicenseType;
        int m_EngineVol;

        protected Motorcycle(int i_EngineVol, eLicenseType i_licenseType, string i_ModelName, string i_LicenseNumber,
            float i_EnergyLevel) : base(i_ModelName, i_LicenseNumber, i_EnergyLevel)
        {


            this.m_LicenseType = i_licenseType;
            this.m_EngineVol = i_EngineVol;
        }
        public override StringBuilder GetFullDetails(string i_FormatString, StringBuilder io_stringBuilder = null)
        {
            io_stringBuilder = base.GetFullDetails(i_FormatString, io_stringBuilder);
            io_stringBuilder.AppendFormat(i_FormatString, "Licende Type", m_LicenseType);
            io_stringBuilder.AppendFormat(i_FormatString, "Engine Volume", m_EngineVol);
            return io_stringBuilder;
        }
    }
}
