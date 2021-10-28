using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ex03.GarageLogic
{
    
    public static class Garage
    {
        static Dictionary<string, GarageVehicle> m_StoredVehicle { get; } = new Dictionary<string, GarageVehicle>();
        public enum eStatus
        {
            InFix,
            Fixed,
            Paid
        }

        public static string AddVehicle(Vehicle i_Vehicle, string i_Onwer, string i_Phone)
        {
            string resMessage = "";

            if (!m_StoredVehicle.ContainsKey(i_Vehicle.m_LicenseNumber))
            {

                m_StoredVehicle.Add(i_Vehicle.m_LicenseNumber, new GarageVehicle(i_Onwer, i_Phone, eStatus.InFix, i_Vehicle));
            }
            else
            {
                resMessage = $"Vehice {i_Vehicle.m_LicenseNumber} already in the Garage! changing status to InFix";
                m_StoredVehicle[i_Vehicle.m_LicenseNumber].m_Status = eStatus.InFix;

            }


            return resMessage;

        }
        public static void PrintGatage(eStatus? i_Filter = null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            
        }

        
    }
}
