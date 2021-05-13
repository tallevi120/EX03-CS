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

    }
}
