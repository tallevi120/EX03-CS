namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

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

        public override string ToString()
        {
            return string.Format(@"License Number: {0}
Model Name: {1}
Maximum Battery Time: {2}
Remaining Battery Time: {3}
Percentage Of Energy Remaining: {4}%
Wheel Manufacturer Name: {5}
Whell Maximum Air Pressure: {6}
Wheel Current Air Pressure: {7}
Car Color: {8}
Number Of Doors: {9}", this.LicenseNumber, this.ModelName, this.MaximumBatteryTime, this.RemainingBatteryTime, 
this.PercentageOfEnergyRemaining, this.VehicleWheels[0].ManufacturerName, this.VehicleWheels[0].MaximumAirPressure, 
this.VehicleWheels[0].CurrentAirPressure, m_CarDetails.Color, m_CarDetails.NumberOfDoors);
        }
    }
}
