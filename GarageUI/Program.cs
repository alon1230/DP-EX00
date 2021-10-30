using System;
using Ex03.GarageLogic;
using System.Text;
using System.Collections.Generic;
using static Ex03.GarageLogic.Garage;
using static Ex03.GarageLogic.Interfaces.IPetrolUser;

namespace GarageUI
{
    class Program
    {
        static void mainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                StringBuilder menuMessage = new StringBuilder();

                menuMessage.AppendLine("Hello! please choose operation by typeing the operaion number:");
                menuMessage.AppendLine($"{"Add vehicle to Garage:",-40}{1,0}");
                menuMessage.AppendLine($"{"Print all Vehicles in the Garage:",-40}{2,0}");
                menuMessage.AppendLine($"{"Change the Status of a Vehicle:",-40}{3,0}");
                menuMessage.AppendLine($"{"Fill Tyres of a vehicle to max:",-40}{4,0}");
                menuMessage.AppendLine($"{"Add fuel to vehicle:",-40}{5,0}");
                menuMessage.AppendLine($"{"Charge Electric Vehicle:",-40}{6,0}");
                menuMessage.AppendLine($"{"Get full details of a vehicle:",-40}{7,0}");
                menuMessage.AppendLine($"{"Exit:",-40}{8,0}");

                int res = chooseFromMenu(1, 8, menuMessage);
                switch (res)
                {
                    case 1:
                        {
                            constractVehicle();
                            break;
                        }
                    case 2:
                        {

                            string message;
                            Utilities.WriteLineYellow("Please Choose a status (InFix, Fixed or Paid) to filter by or view all");
                            StringBuilder stringBuilder = Utilities.MenuOptionsFromEnum(typeof(eStatus));
                            stringBuilder.AppendLine($"{"View All",-7}: {4}");
                            int option = chooseFromMenu(1, 4, stringBuilder);
                            eStatus? status = null;
                            if (option != 4)
                            {
                                status = (eStatus)option - 1;
                            }
                            message = Garage.PrintGarage(status);
                            Console.WriteLine(message);
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                Utilities.WriteLineYellow("Please enter a license number");
                                string licenseNumber = Console.ReadLine();
                                if (checkExistAndPrintError(licenseNumber))
                                {
                                    eStatus status = (eStatus)chooseFromMenu(1, 3, Utilities.MenuOptionsFromEnum(typeof(eStatus))) - 1;
                                    //eStatus status = Utilities.ParseEnumUntilSucceed<eStatus>("Please enter a new valid status (InFix, Fixed or Paid)");                                
                                    string resMessage = Garage.ChangeStatus(licenseNumber, status);
                                    Console.WriteLine(resMessage);
                                }
                            }

                            catch (Exception e)
                            {
                                Utilities.WriteLineRed(e.Message);
                            }
                            break;
                        }

                    case 4:
                        {
                            Utilities.WriteLineYellow("Please enter a license number");
                            string licenseNumber = Console.ReadLine();
                            if (checkExistAndPrintError(licenseNumber))
                            {

                                try
                                {
                                    string resMessage = Garage.FillAirToMax(licenseNumber);
                                    Console.WriteLine(resMessage);

                                }
                                catch (Exception e)
                                {
                                    Utilities.WriteLineRed(e.Message);
                                }

                            }
                            break;
                        }
                    case 5:
                        {
                            Utilities.WriteLineYellow("Please enter a license number");
                            string licenseNumber = Console.ReadLine();
                            if (checkExistAndPrintError(licenseNumber))
                            {
                                Utilities.WriteLineYellow("Please enter a amount to fill");
                                float amount = float.Parse(Console.ReadLine());
                                eFuelType fuelType = (eFuelType)chooseFromMenu(1, 4, Utilities.MenuOptionsFromEnum(typeof(eFuelType))) - 1;


                                try
                                {
                                    Console.WriteLine(Garage.FuelPetrolVehicle(licenseNumber, amount, fuelType));
                                }
                                catch (Exception e)
                                {

                                    Utilities.WriteLineRed(e.Message);
                                }
                            }
                        }

                        break;

                    case 6:
                        {
                            Utilities.WriteLineYellow("Please enter a license number");
                            string licenseNumber = Console.ReadLine();
                            if (checkExistAndPrintError(licenseNumber))
                            {
                                Utilities.WriteLineYellow("Please enter a amount to fill");
                                float amount = float.Parse(Console.ReadLine());
                                try
                                {
                                    string resMessage = Garage.ChargeElectricVehicle(licenseNumber, amount);
                                    Console.WriteLine(resMessage);
                                }
                                catch (Exception e)
                                {

                                    Utilities.WriteLineRed(e.Message);
                                }
                            }
                            break;

                        }
                    case 7:
                        {
                            Utilities.WriteLineYellow("Please enter a license number");
                            string licenseNumber = Console.ReadLine();
                            if (checkExistAndPrintError(licenseNumber))
                            {
                                try
                                {
                                    string resMessage = Garage.GetFullDetials(licenseNumber);
                                    Console.WriteLine(resMessage);
                                }
                                catch (Exception e)
                                {
                                    Utilities.WriteLineRed(e.Message);

                                }
                            }
                            break;
                        }
                    case 8:
                        {
                            Utilities.WriteLineYellow("Thanks for using the system!");
                            exit = true;
                            break;
                        }
                }

            }

        }

        private static void constractVehicle()
        {
            GarageVehicle vehicle = new GarageVehicle();
            Utilities.WriteLineYellow("Choose Vehicle Type");
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{"Petrol Car",-20}{1,20}");
            stringBuilder.AppendLine($"{"Electric Car",-20}{2,20}");
            stringBuilder.AppendLine($"{"Petrol Motorcycle",-20}{3,20}");
            stringBuilder.AppendLine($"{"Electric Motorcycle",-20}{4,20}");
            stringBuilder.AppendLine($"{"Petrol Truck",-20}{5,20}");
            int res = chooseFromMenu(1, 5, stringBuilder);
            Utilities.WriteLineYellow("Enter owner's name");
            vehicle.m_Owner = Console.ReadLine();
            Utilities.WriteLineYellow("Enter owner's phone");
            vehicle.m_Phone = Console.ReadLine();

            switch (res)
            {
                case 1:
                    {
                        PetrolCar tempVehicle = new PetrolCar();
                        SetVehicleMembers(tempVehicle);
                        SetCarMembers(tempVehicle);

                        float airPressure = Utilities.ParseNumberUntilSucceed("Enter tyres air pressure between 0 and 32", 0, 32f);
                        Utilities.WriteLineYellow("enter Tyre manufacturer");
                        string tyreManufacturer = Console.ReadLine();
                        vehicle.m_Vehicle = new PetrolCar(tempVehicle.m_Color, tempVehicle.m_Doors, tempVehicle.m_ModelName, tempVehicle.m_LicenseNumber, tempVehicle.m_EnergyLevel, airPressure, tyreManufacturer);
                        break;
                    }
                case 2:
                    {
                        ECar tempVehicle = new ECar();
                        SetVehicleMembers(tempVehicle);
                        SetCarMembers(tempVehicle);

                        float airPressure = Utilities.ParseNumberUntilSucceed("Enter tyres air pressure between 0 and 32", 0, 32f);
                        Utilities.WriteLineYellow("enter Tyre manufacturer");
                        string tyreManufacturer = Console.ReadLine();
                        vehicle.m_Vehicle = new ECar(tempVehicle.m_Color, tempVehicle.m_Doors, tempVehicle.m_ModelName, tempVehicle.m_LicenseNumber,
                            tempVehicle.m_EnergyLevel, airPressure, tyreManufacturer);
                        break;
                    }
                case 3:
                    {
                        PetrolMotorcycle tempVehicle = new PetrolMotorcycle();
                        SetVehicleMembers(tempVehicle);
                        SetMotorcycleMembers(tempVehicle);
                        float airPressure = Utilities.ParseNumberUntilSucceed("Enter tyres air pressure between 0 and 30", 0, 30f);
                        Utilities.WriteLineYellow("enter Tyre manufacturer");
                        string tyreManufacturer = Console.ReadLine();
                        vehicle.m_Vehicle = new PetrolMotorcycle(tempVehicle.m_EngineVol, tempVehicle.m_LicenseType, tempVehicle.m_ModelName,
                            tempVehicle.m_LicenseNumber, tempVehicle.m_EnergyLevel, airPressure, tyreManufacturer);
                        break;
                    }
                case 4:
                    {
                        EMotorcycle tempVehicle = new EMotorcycle();
                        SetVehicleMembers(tempVehicle);
                        SetMotorcycleMembers(tempVehicle);
                        float airPressure = Utilities.ParseNumberUntilSucceed("Enter tyres air pressure between 0 and 30", 0, 30f);
                        Utilities.WriteLineYellow("enter Tyre manufacturer");
                        string tyreManufacturer = Console.ReadLine();
                        vehicle.m_Vehicle = new EMotorcycle(tempVehicle.m_EngineVol, tempVehicle.m_LicenseType, tempVehicle.m_ModelName,
                            tempVehicle.m_LicenseNumber, tempVehicle.m_EnergyLevel, airPressure, tyreManufacturer);
                        break;
                    }
                case 5:
                    {
                        PetrolTruck tempVehicle = new PetrolTruck();
                        SetVehicleMembers(tempVehicle);
                        //tempVehicle.m_DangerousSubstances = Utilities.ParseBoolUntilSucceed("Dangerous Substances?");
                        stringBuilder.Clear();
                        stringBuilder.AppendLine("Dangerous Substances?");
                        stringBuilder.AppendLine($"{"Yes",-10}:{1,10}");
                        stringBuilder.AppendLine($"{"No",-10}:{2,10}");
                        tempVehicle.m_DangerousSubstances = chooseFromMenu(1, 2, stringBuilder) == 1;
                        tempVehicle.m_MaxLoad = Utilities.ParseNumberUntilSucceed("Enter max load of the truck");
                        float airPressure = Utilities.ParseNumberUntilSucceed("Enter tyres air pressure between 0 and 30", 0, 30f);
                        Utilities.WriteLineYellow("enter Tyre manufacturer");
                        string tyreManufacturer = Console.ReadLine();
                        vehicle.m_Vehicle = new PetrolTruck(tempVehicle.m_ModelName, tempVehicle.m_LicenseNumber, tempVehicle.m_EnergyLevel,
                            tempVehicle.m_MaxLoad, tempVehicle.m_DangerousSubstances, airPressure, tyreManufacturer);
                        break;
                    }

            }
            Utilities.WriteLineYellow(Garage.AddVehicle(vehicle));
        }
        private static void SetVehicleMembers(Vehicle i_Vehicle)
        {
            string res = "";
            while (res == "")
            {
                Utilities.WriteLineYellow("Enter non empty License Number");
                res = Console.ReadLine();
                i_Vehicle.m_LicenseNumber = res;
            }
            Utilities.WriteLineYellow("Enter model name");
            i_Vehicle.m_ModelName = Console.ReadLine();
            i_Vehicle.m_EnergyLevel = Utilities.ParseNumberUntilSucceed("please enter energy level beween 0 and 100", 0, 100);

        }
        private static bool checkExistAndPrintError(string i_LicenseNumber)
        {
            bool res = Garage.m_StoredVehicle.ContainsKey(i_LicenseNumber);
            if (!res)
            {
                Utilities.WriteLineRed($"Vehicle {i_LicenseNumber} does not exist in garage");
            }
            return res;
        }

        private static void SetCarMembers(Car i_Vehicle)
        {

            //int res = 0;
            //bool accepted = false;
            //while (!accepted)
            //{
            //    Utilities.WriteLineYellow("Choose number of doors between 2 and 5");
            //    while (!int.TryParse(Console.ReadLine(), out res))
            //    {
            //        Utilities.WriteLineRed("please Choose a valid number!");
            //    }
            //    if (res >= 2 && res <= 5)
            //    {
            //        accepted = true;
            //    }
            //}
            i_Vehicle.m_Doors = (int)Utilities.ParseNumberUntilSucceed("enter number of doors between 2 and 5", 2, 5, true);
            i_Vehicle.m_Color = (Car.eColor)chooseFromMenu(1, 4, Utilities.MenuOptionsFromEnum(typeof(Car.eColor))) - 1;

        }
        private static void SetMotorcycleMembers(Motorcycle i_Vehicle)
        {
            i_Vehicle.m_EngineVol = (int)Utilities.ParseNumberUntilSucceed("Enter enging volume");
            i_Vehicle.m_LicenseType = (Motorcycle.eLicenseType)chooseFromMenu(1, 4, Utilities.MenuOptionsFromEnum(typeof(Motorcycle.eLicenseType))) - 1;
        }

        static int chooseFromMenu(int i_MinValue, int i_MaxValue, StringBuilder menuMessage)
        {
            int res = 0;
            bool accepted = false;
            while (!accepted)
            {
                Console.WriteLine(menuMessage);
                if (int.TryParse(Console.ReadLine(), out res))
                {
                    if (res < i_MinValue || res > i_MaxValue)
                    {
                        Utilities.WriteLineRed($"Selected value is out of range of {i_MinValue} to {i_MaxValue}");
                        continue;

                    }
                    accepted = true;

                }
                else
                {

                    Utilities.WriteLineRed($"Please select a number between {i_MinValue} to {i_MaxValue}");
                    continue;
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            mainMenu();
        }

    }


}


