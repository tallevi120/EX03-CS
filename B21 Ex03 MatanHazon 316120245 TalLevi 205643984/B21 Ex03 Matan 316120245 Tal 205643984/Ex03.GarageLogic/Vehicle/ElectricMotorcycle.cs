using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicles
    {
        private Motorcycle m_MotorcycleDetails;

        public Motorcycle MotorcycleDetails
        {
            get
            {
                return m_MotorcycleDetails;
            }
            set
            {
                m_MotorcycleDetails = value;
            }
        }

        public ElectricMotorcycle(string i_ModelName, string i_LicenceNumber, List<Wheel> i_Wheels, eMotorcycleLicenseType i_LicenseType,
            int i_EngineCc, float i_WorkHoursRemining, float i_MotorcycleMaxElectricPower, float i_PercentageOfEnergyRemaining)
        {
            m_MotorcycleDetails = new Motorcycle(i_LicenseType, i_EngineCc);
            ModelName = i_ModelName;
            LicenseNumber = i_LicenceNumber;
            RemainingBatteryTime = i_WorkHoursRemining;
            VehicleWheels = i_Wheels;
            MaximumBatteryTime = i_MotorcycleMaxElectricPower;
            PercentageOfEnergyRemaining = i_PercentageOfEnergyRemaining;
        }
    }
}
