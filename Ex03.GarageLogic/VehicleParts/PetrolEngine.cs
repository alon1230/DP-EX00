using Ex03.GarageLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Interfaces.IPetrolUser;

namespace Ex03.GarageLogic
{
    public class PetrolEngine : Engine,IPetrolUser
    {
        
        eFuelType m_FuelType;

        public PetrolEngine(eFuelType i_FuelType,float i_EngineEnergyRemaining, float i_MaxEngineEnergy) : base(i_EngineEnergyRemaining, i_MaxEngineEnergy)
        {
            this.m_FuelType = i_FuelType;
        }
        public void ChargeEngine(float i_AddedEnergy,eFuelType i_FuelType, Action updateEnergylevel)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException($"Fuel Type: {i_FuelType} is inconsistant with fuel type of the engine {m_FuelType}");
            }
            ChargeEngine(i_AddedEnergy, updateEnergylevel);
        }
        public override StringBuilder GetEngineDetails(string i_FormatString, StringBuilder io_stringBuilder)
        {
            io_stringBuilder.AppendFormat(i_FormatString, "Fuel type", m_FuelType);
            io_stringBuilder.AppendFormat(i_FormatString, "Fuel left", $"{m_EngineEnergyRemaining} liters out of {m_MaxEngineEnergy}");
            return io_stringBuilder;
        }
    }
    
}

       