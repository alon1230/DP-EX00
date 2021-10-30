using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string m_ModelName { get; set; }
        public string m_LicenseNumber { get; set; }
        public float m_EnergyLevel { get; set; }
        public List<Tyre> m_Tyres { get; }
        public Engine m_Engine;

        protected Vehicle(string i_ModelName, string i_LicenseNumber,float i_EnergyLevel)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_EnergyLevel = i_EnergyLevel;
            this.m_Tyres = new List<Tyre>(); 
            
            
        }
        protected Vehicle() { }
        protected void CreateTyreList(int i_NumOfTyres,string i_TyreManufacturer, float i_AirPressure,float i_MaxAirPressure)
        {
            for(int i = 0; i < i_NumOfTyres; i++)
            {
                this.m_Tyres.Add(new Tyre(i_TyreManufacturer, i_AirPressure, i_MaxAirPressure));
            }
        }
        public void UpdateEnergyLevel()
        {
            m_EnergyLevel = m_Engine.m_EngineEnergyRemaining / m_Engine.m_MaxEngineEnergy;   
        }
        public virtual StringBuilder GetFullDetails(string i_FormatString, StringBuilder io_StringBuilder = null)
        {
            if(io_StringBuilder == null)
            {
                io_StringBuilder = new StringBuilder();
            }
            io_StringBuilder.AppendFormat(i_FormatString, "License Number", this.m_LicenseNumber);
            io_StringBuilder.AppendFormat(i_FormatString, "Model Name", this.m_ModelName);
            foreach (var tuple in this.m_Tyres.Select((tyre, i) => new { i, tyre }))
            {
                io_StringBuilder.AppendFormat(i_FormatString, $"Tyre {tuple.i + 1} of manufacturer {tuple.tyre.m_Manufacturer} ", $"{tuple.tyre.m_AirPressure} PSI");
            }
            m_Engine.GetEngineDetails(i_FormatString,io_StringBuilder);
            return io_StringBuilder;
        }
       
    }
}
    