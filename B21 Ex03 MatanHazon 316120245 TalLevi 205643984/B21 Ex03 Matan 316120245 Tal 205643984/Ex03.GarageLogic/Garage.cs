namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Garage
    {
        private List<VehicleInTheGarage> m_ListOfVehicles;

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

        }

        public void ShowAllLicenseNumbers()
        {

        }

        public void ShowLicenseNumbersWithSameStatus(eVehicleStatus i_Status)
        {

        }

        public void ChangeStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {

        }

        public void InflatingWheelsToMax(string i_LicenseNumber)
        {

        }

        public void Refueling(string i_LicenseNumber, eFuelType i_TypeOfFuel, float i_HowMuchFuelToAdd)
        {

        }

        public void BatteryCharging(string i_LicenseNumber, float i_AmountOfChargingHours)
        {

        }

        public void DetailsAboutVehicle(string i_LicenseNumber)
        {

        }

        public bool IfVehicleExists(string i_LicensePlate)
        {
            bool isExists = false;
            foreach(VehicleInTheGarage vehicle in m_ListOfVehicles)
            {
                if (vehicle.Vehicle.LicenseNumber == i_LicensePlate)
                {
                    isExists = true;
                    break;
                }
            }

            return isExists;
        }

    }
}
