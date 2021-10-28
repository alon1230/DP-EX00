using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class GarageVehicle
    {
       

        public string m_Phone { get; set; }

        public Garage.eStatus m_Status { get; set; } = Garage.eStatus.InFix;
        public Vehicle m_Vehicle { get; set; }

        public string m_Owner { get; set; }
        public GarageVehicle(string i_Owner, string i_Phone, Garage.eStatus i_Status, Vehicle i_Vehicle)
        {
            m_Owner = i_Owner;
            m_Phone = i_Phone;
            m_Status = i_Status;
            m_Vehicle = i_Vehicle;
        }



    }
}
