using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    public static class VehicleConstructor
    {
        public static PetrolCar CreatePertolCar ( string i_ModelName, string i_LicenseNumber, float i_EnergyLevel = 45f, float i_AirPressure=32f, eColor i_Color = eColor.grey, int i_Doors=4, string i_TyreManufacturer = "")
        {
            return new PetrolCar(i_Color, i_Doors, i_ModelName, i_LicenseNumber, i_EnergyLevel, i_AirPressure, i_TyreManufacturer);
        }
        public static ECar CreateECar(string i_ModelName, string i_LicenseNumber, float i_EnergyLevel=3.2f, float i_AirPressure=32f, eColor i_Color = eColor.grey, int i_Doors = 4, string i_TyreManufacturer = "")
        {
            return new ECar(i_Color, i_Doors, i_ModelName, i_LicenseNumber, i_EnergyLevel, i_AirPressure, i_TyreManufacturer);
        }
        public static PetrolMotorcycle CreatePertolMotorcycle (int i_EngineVol, eLicenseType i_licenseType, string i_ModelName, string i_LicenseNumber,
            float i_EnergyLevel=6f, float i_AirPressure=30f, string i_TyreManufacturer = "")
        {
            return new PetrolMotorcycle(i_EngineVol, i_licenseType, i_ModelName, i_LicenseNumber, i_EnergyLevel, i_AirPressure, i_TyreManufacturer);
        }
        public static EMotorcycle CreatEMotorcycle(int i_EngineVol, eLicenseType i_licenseType, string i_ModelName, string i_LicenseNumber,
            float i_EnergyLevel = 6f, float i_AirPressure = 30f, string i_TyreManufacturer = "")
        {
            return new EMotorcycle(i_EngineVol, i_licenseType, i_ModelName, i_LicenseNumber, i_EnergyLevel, i_AirPressure, i_TyreManufacturer);
        }
        public static PetrolTruck CreatePertolTruck(string i_ModelName, string i_LicenseNumber,  float i_MaxLoad, bool i_DangerousSubstances,
           float i_EnergyLevel=115f, float i_AirPressure=28f, string i_TyreManufacturer = "")
        {
            return new PetrolTruck(i_ModelName, i_LicenseNumber, i_EnergyLevel, i_MaxLoad, i_DangerousSubstances, i_AirPressure, i_TyreManufacturer);
        }

    }
}
