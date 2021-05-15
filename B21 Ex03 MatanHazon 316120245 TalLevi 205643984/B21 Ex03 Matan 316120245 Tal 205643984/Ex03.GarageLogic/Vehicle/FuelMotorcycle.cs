using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
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
Engine Capacity: {12}
License Type: {13}", this.LicenseNumber, this.ModelName, this.OwnerName, this.OwnerPhone, this.VehicleStatus, this.TypeOfFuel,
                this.MaximumAmountOfFuel, this.CurrentAmountOfFuel, this.PercentageOfEnergyRemaining,
                this.VehicleWheels[0].ManufacturerName, this.VehicleWheels[0].MaximumAirPressure,
                this.VehicleWheels[0].CurrentAirPressure, m_MotorcycleDetails.EngineCapacity, m_MotorcycleDetails.LicenseType);
        }
    }
}
