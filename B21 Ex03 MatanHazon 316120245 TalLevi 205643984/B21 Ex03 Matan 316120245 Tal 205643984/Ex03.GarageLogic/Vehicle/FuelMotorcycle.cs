namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

    public class FuelMotorcycle : FuelVehicles
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

        public FuelMotorcycle(string i_ModelName, string i_LicenceNumber, List<Wheel> i_Wheels, eMotorcycleLicenseType i_LicenseType,
            int i_EngineCc, float i_CurrentFuelAmount, float i_MotorcycleMaxFuel, eFuelType i_MotorcycleFuelType, 
            float i_PercentageOfEnergyRemaining)
        {
            m_MotorcycleDetails = new Motorcycle(i_LicenseType, i_EngineCc);
            ModelName = i_ModelName;
            LicenseNumber = i_LicenceNumber;
            CurrentAmountOfFuel = i_CurrentFuelAmount;
            VehicleWheels = i_Wheels;
            MaximumAmountOfFuel = i_MotorcycleMaxFuel;
            TypeOfFuel = i_MotorcycleFuelType;
            PercentageOfEnergyRemaining = i_PercentageOfEnergyRemaining;
        }

        public override string ToString()
        {
            return string.Format(@"License Number: {0}
Model Name: {1}
Vehicle Status: {2}
Type Of Fuel: {3}
Maximum Amount Of Fuel: {4}
Current Amount Of Fuel: {5}
Percentage Of Energy Remaining: {6}%
Wheel Manufacturer Name: {7}
Whell Maximum Air Pressure: {8}
Wheel Current Air Pressure: {9}
Engine Capacity: {10}
License Type: {11}", this.LicenseNumber, this.ModelName, this.VehicleStatus, this.TypeOfFuel,
                this.MaximumAmountOfFuel, this.CurrentAmountOfFuel, this.PercentageOfEnergyRemaining,
                this.VehicleWheels[0].ManufacturerName, this.VehicleWheels[0].MaximumAirPressure,
                this.VehicleWheels[0].CurrentAirPressure, m_MotorcycleDetails.EngineCapacity, m_MotorcycleDetails.LicenseType);
        }
    }
}
