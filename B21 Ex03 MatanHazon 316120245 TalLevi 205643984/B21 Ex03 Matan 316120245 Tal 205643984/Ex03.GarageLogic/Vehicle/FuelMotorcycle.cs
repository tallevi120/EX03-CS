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
    }
}
