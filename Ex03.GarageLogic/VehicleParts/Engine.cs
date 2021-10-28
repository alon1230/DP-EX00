using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Interfaces;

namespace Ex03.GarageLogic
{
    public class Engine: IElectricUser
    {
        float m_EngineEnergyRemaining;
        float m_MaxEngineEnergy;

        public Engine(float i_EngineEnergyRemaining, float i_MaxEngineEnergy)
        {
            this.m_MaxEngineEnergy = i_MaxEngineEnergy;
            this.m_EngineEnergyRemaining = i_EngineEnergyRemaining;
        }
        public void ChargeEngine(float i_AddedEnergy)
        {
            if (m_EngineEnergyRemaining + i_AddedEnergy <= m_MaxEngineEnergy)
            {
                m_EngineEnergyRemaining += i_AddedEnergy;
            }
            else
            {
                throw new ValueOutOfRangeException("Charged EV more than allowed");
            }
        }
    }
}
