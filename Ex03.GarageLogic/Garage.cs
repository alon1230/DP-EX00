using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Ex03.GarageLogic.Interfaces.IPetrolUser;

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
        public static string PrintGatage(eStatus? i_Filter = null)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (m_StoredVehicle.Count == 0)
            {
                stringBuilder.AppendLine("The Garage is empty!");
            }

            Dictionary<string, GarageVehicle> relevantDict = m_StoredVehicle;

            if (i_Filter != null)
            {
                relevantDict = m_StoredVehicle.Where(v => v.Value.m_Status == i_Filter).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }

            foreach (KeyValuePair<string, GarageVehicle> kvp in relevantDict)
            {
                stringBuilder.AppendLine($"Vehicle {kvp.Key} status is '{kvp.Value.m_Status.ToString()}'");
            }
            return stringBuilder.ToString();


        }
        public static string ChangeStatus(string i_LicenseNumber, eStatus i_NewStatus)
        {
            string messege = $"Vehicle {i_LicenseNumber} status has been changed to {i_NewStatus}";
            try
            {
                m_StoredVehicle[i_LicenseNumber].m_Status = i_NewStatus;
            }
            catch (KeyNotFoundException)
            {
                messege = $"Vehicle {i_LicenseNumber} was not found in the Garage. Do you wish to add it?";
            }
            return messege;
        }
        public static string FillAirToMax(string i_LicenseNumber)
        {
            string messege = $"Vehicle {i_LicenseNumber} tyres were filled to max";
            try
            {
                Vehicle vehicle = m_StoredVehicle[i_LicenseNumber].m_Vehicle;
                foreach (Tyre tyre in vehicle.m_Tyres)
                {
                    tyre.FillAir(tyre.m_MaxAirPressure - tyre.m_AirPressure);
                }
            }
            catch (KeyNotFoundException)
            {
                messege = $"Vehicle {i_LicenseNumber} was not found in the Garage. Do you wish to add it?";
            }
            return messege;
        }
        public static string FuelPetrolVehicle(string i_LicenseNumber, float i_Amount, eFuelType i_FuelType)
        {
            string message = $"Vehicle {i_LicenseNumber} was toped with {i_Amount} of {i_FuelType} fuel";
            try
            {

                Vehicle vehicle = m_StoredVehicle[i_LicenseNumber].m_Vehicle;
                if (vehicle is Interfaces.IPetrolUser)
                {
                    (vehicle as Interfaces.IPetrolUser).ChargeEngine(i_Amount, i_FuelType,vehicle.UpdateEnergyLevel);
                }
                else
                {
                    message = $"Vehile {i_LicenseNumber} is not a Petrol vehicle!";
                }

            }
            catch(ArgumentException e)
            {
                message = e.Message + $" of Vehicle {i_LicenseNumber}";
            }
            catch (KeyNotFoundException)
            {
                message = $"Vehicle {i_LicenseNumber} was not found in the Garage. Do you wish to add it?";
            }
            catch (ValueOutOfRangeException e)
            {
                Vehicle vehicle = m_StoredVehicle[i_LicenseNumber].m_Vehicle; //if we got here there will be no KeyNotFoundException
                message = $"Vehicle {i_LicenseNumber} have {vehicle.m_Engine.m_EngineEnergyRemaining} Fuel left in it. charging it with {i_Amount} of {i_FuelType} will exceed the max amout of {e.m_MaxValue}." +
                    $" please charge no more than {e.m_MaxValue - vehicle.m_Engine.m_EngineEnergyRemaining}";
            }
            return message;
        }

                   
        
        public static string ChargeElectricVehicle(string i_LicenseNumber,float i_Amount)
        {
            string message = $"ELectric vehicle {i_LicenseNumber} have been charged with {i_Amount} hours";
            try
            {
                Vehicle vehicle = m_StoredVehicle[i_LicenseNumber].m_Vehicle;
                if (vehicle is Interfaces.IElectricUser)
                {
                    (vehicle as Interfaces.IElectricUser).ChargeEngine(i_Amount/60,vehicle.UpdateEnergyLevel);
                }
            }
            catch (KeyNotFoundException)
            {
                message = $"Vehicle {i_LicenseNumber} was not found in the Garage. Do you wish to add it?";
            }
            catch (ValueOutOfRangeException e)
            {
                Vehicle vehicle = m_StoredVehicle[i_LicenseNumber].m_Vehicle; //if we got here there will be no KeyNotFoundException
                message = $"Vehicle {i_LicenseNumber} have {vehicle.m_Engine.m_EngineEnergyRemaining} hours in it. charging it with {i_Amount} will exceed the max amout of {e.m_MaxValue}." +
                    $" please charge no more than {(e.m_MaxValue - vehicle.m_Engine.m_EngineEnergyRemaining)*60} minuets";
            }

            return message;
        }
        public static string GetFullDetials(string i_LicenseNumber)
        {
            string res = "";
            try
            {
                string formatString = "{0,-15}: {1,5}\n";
                GarageVehicle vehicle = m_StoredVehicle[i_LicenseNumber];
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Details for Vehicle {i_LicenseNumber}");            
                stringBuilder.AppendFormat(formatString, "Owner Name:", vehicle.m_Owner);
                stringBuilder.AppendFormat(formatString, "Status:", vehicle.m_Status);              



            }
            catch (KeyNotFoundException)
            {
                res = $"Vehicle {i_LicenseNumber} was not found in the Garage. Do you wish to add it?";
            }
            return res;
        }


    }
}
