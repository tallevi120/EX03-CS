using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
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
Owner Name: {2}
Owner Phone: {3}
Vehicle Status: {4}
Type Of Fuel: {5}
Maximum Amount Of Fuel: {6}
Current Amount Of Fuel: {7}
Percentage Of Energy Remaining: {8}%
Wheel Manufacturer Name: {9}
Whell Maximum Air Pressure: {10}
Wheel Current Air Pressure: {11}
Maximum Carrying Weight: {12}
Driving Hazardous Materials? {13}", this.LicenseNumber, this.ModelName, this.OwnerName, this.OwnerPhone, this.VehicleStatus, this.TypeOfFuel,
                this.MaximumAmountOfFuel, this.CurrentAmountOfFuel, this.PercentageOfEnergyRemaining,
                this.VehicleWheels[0].ManufacturerName, this.VehicleWheels[0].MaximumAirPressure,
                this.VehicleWheels[0].CurrentAirPressure, m_TruckDetails.MaximumCarryingWeight, m_TruckDetails.IfDrivingHazardousMaterials);
        }

    }
}
