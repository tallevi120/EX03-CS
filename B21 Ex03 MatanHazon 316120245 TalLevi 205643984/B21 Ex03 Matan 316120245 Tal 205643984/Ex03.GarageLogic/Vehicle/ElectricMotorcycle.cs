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

        public override string ToString()
        {
            return string.Format(@"License Number: {0}
Model Name: {1}
Owner Name: {2}
Owner Phone: {3}
Vehicle Status: {4}
Maximum Battery Time: {5}
Remaining Battery Time: {6}
Percentage Of Energy Remaining: {7}%
Wheel Manufacturer Name: {8}
Whell Maximum Air Pressure: {9}
Wheel Current Air Pressure: {10}
Engine Capacity: {11}
License Type: {12}", this.LicenseNumber, this.ModelName, this.OwnerName, this.OwnerPhone, this.VehicleStatus,
                this.MaximumBatteryTime, this.RemainingBatteryTime, this.PercentageOfEnergyRemaining,
                this.VehicleWheels[0].ManufacturerName, this.VehicleWheels[0].MaximumAirPressure,
                this.VehicleWheels[0].CurrentAirPressure, m_MotorcycleDetails.EngineCapacity, m_MotorcycleDetails.LicenseType);
        }
    }
}
