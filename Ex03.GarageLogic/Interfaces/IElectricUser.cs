using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Interfaces
{
    public interface IElectricUser
    {
        public void ChargeEngine(float i_Time, Action updateEnergylever);
    }
}
