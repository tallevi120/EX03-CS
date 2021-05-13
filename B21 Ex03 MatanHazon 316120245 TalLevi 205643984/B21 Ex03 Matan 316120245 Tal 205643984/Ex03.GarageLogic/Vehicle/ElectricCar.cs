using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicles
    {
        private Car m_CarDetails;

        public Car CarDetails
        {
            get
            {
                return m_CarDetails;
            }
            set
            {
                m_CarDetails = value;
            }
        }
        public ElectricCar(string i_ModelName, string i_LicenceNumber, List<Wheel> i_Wheels, eColorsForCar i_CarColor, eNumOfDoors i_Doors,
            float i_WorkHoursRemining, float i_CarMaxElectricPower, float i_PercentageOfEnergyRemaining)
        {
            m_CarDetails = new Car(i_CarColor, i_Doors);
            ModelName = i_ModelName;
            LicenseNumber = i_LicenceNumber;
            RemainingBatteryTime = i_WorkHoursRemining;
            VehicleWheels = i_Wheels;
            MaximumBatteryTime = i_CarMaxElectricPower;
            PercentageOfEnergyRemaining = i_PercentageOfEnergyRemaining;
        }
    }
}
