using System;
using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_EnergyLevel;
        protected List<Tyre> m_Tyres;
        protected Engine m_Engine;

        protected Vehicle(string i_ModelName, string i_LicenseNumber,float i_EnergyLevel)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_EnergyLevel = i_EnergyLevel;
            this.m_Tyres = new List<Tyre>(); 
            
            
        }
        protected void CreateTyreList(int i_NumOfTyres,string i_TyreManufacturer, float i_AirPressure,float i_MaxAirPressure)
        {
            for(int i = 0; i < i_NumOfTyres; i++)
            {
                this.m_Tyres.Add(new Tyre(i_TyreManufacturer, i_AirPressure, i_MaxAirPressure));
            }
        }
        
        
    }
}
    