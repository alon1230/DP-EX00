using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class GarageVehicle
    {
       

        string m_Phone { get; set; }

        Garage.eStatus m_Status { get; set; } = Garage.eStatus.InFix;
        Vehicle m_Vehicle { get; set; }

        string m_Owner { get; set; }
        public GarageVehicle(string i_Owner, string i_Phone, Garage.eStatus i_Status, Vehicle i_Vehicle)
        {
            m_Owner = i_Owner;
            m_Phone = i_Phone;
            m_Status = i_Status;
            m_Vehicle = i_Vehicle;
        }



    }
}
