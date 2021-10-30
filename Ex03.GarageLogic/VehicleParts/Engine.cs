using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Interfaces;

namespace Ex03.GarageLogic
{
    public class Engine: IElectricUser
    {
        public float m_EngineEnergyRemaining { get; set; }
        public float m_MaxEngineEnergy { get; }

        public Engine(float i_EngineEnergyRemaining, float i_MaxEngineEnergy)
        {
            this.m_MaxEngineEnergy = i_MaxEngineEnergy;
            this.m_EngineEnergyRemaining = i_EngineEnergyRemaining;
        }
        public void ChargeEngine(float i_AddedEnergy,Action updateEnergylevel)
        {
            if (m_EngineEnergyRemaining + i_AddedEnergy <= m_MaxEngineEnergy)
            {
                m_EngineEnergyRemaining += i_AddedEnergy;
                updateEnergylevel();
            }
            else
            {
                throw new ValueOutOfRangeException(0,m_MaxEngineEnergy);
            }
        }
        public virtual StringBuilder GetEngineDetails(string i_FormatString, StringBuilder io_stringBuilder)
        {
            io_stringBuilder.AppendFormat(i_FormatString, "Energy left", $"{m_EngineEnergyRemaining} hours out of {m_MaxEngineEnergy}");
            return io_stringBuilder;
        }
    }
}
