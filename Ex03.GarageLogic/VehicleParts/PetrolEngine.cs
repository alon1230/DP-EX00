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
        public void ChargeEngine(float i_AddedEnergy,eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException(string.Format("Fuel Type: {0} is inconsistant with fuel type of the engine {1}", i_FuelType, m_FuelType));
            }
            ChargeEngine(i_AddedEnergy);
        }
    }
    
}

       