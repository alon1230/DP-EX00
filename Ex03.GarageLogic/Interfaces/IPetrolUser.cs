using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Interfaces
{
    public interface IPetrolUser
    {
        public enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }
        public void ChargeEngine(float i_Fuel,eFuelType i_FuelType, Action updateEnergylever);
    }
}
