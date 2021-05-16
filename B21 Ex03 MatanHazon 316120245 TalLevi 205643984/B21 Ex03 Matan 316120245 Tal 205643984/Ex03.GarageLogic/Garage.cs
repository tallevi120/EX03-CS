namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class Garage
    {
        private List<VehicleInTheGarage> m_ListOfVehicles = new List<VehicleInTheGarage>();

        public List<VehicleInTheGarage> ListOfVehicles
        {
            get
            {
                return m_ListOfVehicles;
            }

            set
            {
                m_ListOfVehicles = value;
            }
        }


        public void InsertVehicleIntoGarage(VehicleInTheGarage i_VehicleToAdd)
        {
            if (IfVehicleExists(i_VehicleToAdd.Vehicle.LicenseNumber))
            {
                throw new ArgumentException("Vehicle already exists");
            }

            m_ListOfVehicles.Add(i_VehicleToAdd);
        }

        public List<string> ShowAllLicenseNumbers()
        {
            return GetLicenceNumbersInGarage(eVehicleStatus.InRepair | eVehicleStatus.Fixed | eVehicleStatus.PaidUp);
        }

        public List<string> ShowLicenseNumbersWithSameStatus(eVehicleStatus i_Status)
        {
            return GetLicenceNumbersInGarage(i_Status);
        }

        public void ChangeStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            if (!IfVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle does not exists");
            }
           
            foreach (VehicleInTheGarage vehicle in m_ListOfVehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicle.VehicleStatus = i_NewStatus;
                    break;
                }
            }
            
        }

        public void InflatingWheelsToMax(string i_LicenseNumber)
        {
            if (!IfVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            foreach (VehicleInTheGarage vehicle in m_ListOfVehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    foreach (Wheel wheel in vehicle.Vehicle.VehicleWheels)
                    {
                        wheel.InflatingWheels(wheel.MaximumAirPressure - wheel.CurrentAirPressure);
                    }
                    break;
                }
            }           
        }

        public void Refueling(string i_LicenseNumber, eFuelType i_TypeOfFuel, float i_HowMuchFuelToAdd)
        {
            if (!IfVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            foreach (VehicleInTheGarage vehicle in m_ListOfVehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    if (vehicle.Vehicle is FuelVehicles)
                    {
                        try
                        {

                        }
                        catch(FormatException ex)
                        {

                        }
                        (vehicle.Vehicle as FuelVehicles).Refueling(i_HowMuchFuelToAdd, i_TypeOfFuel);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("This is not a fuel vehicle");
                    }
                }
            }            
        }

        public void BatteryCharging(string i_LicenseNumber, float i_AmountOfChargingHours)
        {
            if (!IfVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            foreach (VehicleInTheGarage vehicle in m_ListOfVehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    if(vehicle.Vehicle is ElectricVehicles)
                    {
                        (vehicle.Vehicle as ElectricVehicles).BatteryCharging(i_AmountOfChargingHours);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("This is not a electric vehicle");
                    }
                        
                }
            }            
        }

        public string DetailsAboutVehicle(string i_LicenseNumber)
        {
            string vehicleReport = "";
            if (!IfVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            
            foreach (VehicleInTheGarage vehicle in m_ListOfVehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    Console.WriteLine(string.Format(@"Owner Name: {0}
Owner Phone: {1}", vehicle.OwnerName, vehicle.OwnerPhone));
                    vehicleReport = vehicle.Vehicle.ToString();
                }
            }
            
            return vehicleReport;
        }

        public bool IfVehicleExists(string i_LicensePlate)
        {
            bool isExists = false;

            foreach (VehicleInTheGarage vehicle in m_ListOfVehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LicensePlate)
                {
                    isExists = true;
                    break;
                }
            }           

            return isExists;
        }

        private List<string> GetLicenceNumbersInGarage(eVehicleStatus i_VehicleStatus)
        {
            List<string> licenseNumber = new List<string>();
            
            foreach (var vehicle in m_ListOfVehicles)
            {
                if (i_VehicleStatus == vehicle.VehicleStatus)
                {
                    licenseNumber.Add(vehicle.Vehicle.LicenseNumber);
                }
            }
            
            return licenseNumber;
        }

    }
}
