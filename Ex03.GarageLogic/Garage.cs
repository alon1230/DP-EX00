using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Ex03.GarageLogic.Interfaces.IPetrolUser;

namespace Ex03.GarageLogic
{

    public static class Garage
    {
        public static Dictionary<string, GarageVehicle> m_StoredVehicle { get; } = new Dictionary<string, GarageVehicle>();
        public enum eStatus
        {
            InFix,
            Fixed,
            Paid
        }

        public static string AddVehicle(GarageVehicle i_Vehicle)
        {
            string resMessage = "";

            if (!m_StoredVehicle.ContainsKey(i_Vehicle.m_Vehicle.m_LicenseNumber))
            {

                m_StoredVehicle[i_Vehicle.m_Vehicle.m_LicenseNumber] = i_Vehicle;
            }
            else
            {
                resMessage = $"Vehice {i_Vehicle.m_Vehicle.m_LicenseNumber} already in the Garage! changing status to InFix and dropping changes";
                m_StoredVehicle[i_Vehicle.m_Vehicle.m_LicenseNumber].m_Status = eStatus.InFix;

            }


            return resMessage;

        }
        public static string PrintGarage(eStatus? i_Filter = null)
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
            if (relevantDict.Count == 0)
            {
                stringBuilder.AppendLine("No vehicles match the provided filter");
            }

            foreach (KeyValuePair<string, GarageVehicle> kvp in relevantDict)
            {
                stringBuilder.AppendLine($"Vehicle {kvp.Key} status is '{kvp.Value.m_Status}'");
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
                messege = $"Vehicle {i_LicenseNumber} was not found in the Garage.";
                throw new Exception(messege);
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
                messege = $"Vehicle {i_LicenseNumber} was not found in the Garage.";
                throw new Exception(messege);
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
                    (vehicle as Interfaces.IPetrolUser).ChargeEngine(i_Amount, i_FuelType, vehicle.UpdateEnergyLevel);
                }
                else
                {

                    throw new ArgumentException($"Vehile {i_LicenseNumber} is not a Petrol vehicle!");
                }

            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }
            catch (KeyNotFoundException)
            {
                message = $"Vehicle {i_LicenseNumber} was not found in the Garage.";
                throw new Exception(message);

            }
            catch (ValueOutOfRangeException e)
            {
                Vehicle vehicle = m_StoredVehicle[i_LicenseNumber].m_Vehicle; //if we got here there will be no KeyNotFoundException
                message = $"Vehicle {i_LicenseNumber} have {vehicle.m_Engine.m_EngineEnergyRemaining} Fuel left in it. charging it with {i_Amount} of {i_FuelType} will exceed the max amout of {e.m_MaxValue}." +
                    $" please charge no more than {e.m_MaxValue - vehicle.m_Engine.m_EngineEnergyRemaining}";
                throw new Exception(message);
            }
            return message;
        }



        public static string ChargeElectricVehicle(string i_LicenseNumber, float i_Amount)
        {
            string message = $"ELectric vehicle {i_LicenseNumber} have been charged with {i_Amount} minuets";
            try
            {
                Vehicle vehicle = m_StoredVehicle[i_LicenseNumber].m_Vehicle;
                if (vehicle is Interfaces.IElectricUser)
                {
                    (vehicle as Interfaces.IElectricUser).ChargeEngine(i_Amount / 60, vehicle.UpdateEnergyLevel);
                }
                else
                {

                    throw new ArgumentException($"Vehile {i_LicenseNumber} is not a Electric vehicle!");
                }
            }
            catch (KeyNotFoundException)
            {
                message = $"Vehicle {i_LicenseNumber} was not found in the Garage.";
                throw new Exception(message);
            }
            catch (ValueOutOfRangeException e)
            {
                Vehicle vehicle = m_StoredVehicle[i_LicenseNumber].m_Vehicle; //if we got here there will be no KeyNotFoundException
                message = $"Vehicle {i_LicenseNumber} have {vehicle.m_Engine.m_EngineEnergyRemaining} hours in it. charging it with {i_Amount} will exceed the max amout of {e.m_MaxValue}." +
                    $" please charge no more than {(e.m_MaxValue - vehicle.m_Engine.m_EngineEnergyRemaining) * 60} minuets";
                throw new Exception(message);
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
                stringBuilder.AppendFormat(formatString, "Owner Name", vehicle.m_Owner);
                stringBuilder.AppendFormat(formatString, "Status", vehicle.m_Status);
                stringBuilder = vehicle.m_Vehicle.GetFullDetails(formatString, stringBuilder);
                res = stringBuilder.ToString();



            }
            catch (KeyNotFoundException)
            {
                res = $"Vehicle {i_LicenseNumber} was not found in the Garage.";
                throw new Exception(res);
            }
            return res;
        }


    }
}
