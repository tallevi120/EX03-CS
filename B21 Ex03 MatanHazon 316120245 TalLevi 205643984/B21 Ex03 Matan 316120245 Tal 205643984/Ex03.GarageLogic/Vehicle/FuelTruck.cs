namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

    public class FuelTruck : FuelVehicles
    {
        private Truck m_TruckDetails;

        public Truck TruckDetails
        {
            get
            {
                return m_TruckDetails;
            }

            set
            {
                m_TruckDetails = value;
            }
        }

        public FuelTruck(string i_ModelName, string i_LicenceNumber, List<Wheel> i_Wheels, float i_MaxCargoWeightAllowed,
            float i_CurrentFuelAmount, float i_TruckMaxFuel, bool i_IsCarryngDangerousMaterials, eFuelType i_TruckFuelType,
            float i_PercentageOfEnergyRemaining)
        {
            m_TruckDetails = new Truck(i_MaxCargoWeightAllowed, i_IsCarryngDangerousMaterials);
            ModelName = i_ModelName;
            LicenseNumber = i_LicenceNumber;
            CurrentAmountOfFuel = i_CurrentFuelAmount;
            VehicleWheels = i_Wheels;
            MaximumAmountOfFuel = i_TruckMaxFuel;
            TypeOfFuel = i_TruckFuelType;
            PercentageOfEnergyRemaining = i_PercentageOfEnergyRemaining;
        }

        public override string ToString()
        {
            return string.Format(@"License Number: {0}
Model Name: {1}
Type Of Fuel: {2}
Maximum Amount Of Fuel: {3}
Current Amount Of Fuel: {4}
Percentage Of Energy Remaining: {5}%
Wheel Manufacturer Name: {6}
Whell Maximum Air Pressure: {7}
Wheel Current Air Pressure: {8}
Maximum Carrying Weight: {9}
Driving Hazardous Materials? {10}", this.LicenseNumber, this.ModelName, this.TypeOfFuel, this.MaximumAmountOfFuel, this.CurrentAmountOfFuel, 
this.PercentageOfEnergyRemaining, this.VehicleWheels[0].ManufacturerName, this.VehicleWheels[0].MaximumAirPressure, 
this.VehicleWheels[0].CurrentAirPressure, m_TruckDetails.MaximumCarryingWeight, m_TruckDetails.IfDrivingHazardousMaterials);
        }
    }
}
