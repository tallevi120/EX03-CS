using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicles
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


        public FuelCar(string i_ModelName, string i_LicenceNumber, float i_CurrentFuelAmount, List<Wheel> i_Wheels,
            eColorsForCar i_CarColor, eNumOfDoors i_Doors, float i_CarMaxFuel, eFuelType i_CarFuelType ,float i_PercentageOfEnergyRemaining)
        {
            m_CarDetails = new Car(i_CarColor, i_Doors);
            ModelName = i_ModelName;
            LicenseNumber = i_LicenceNumber;
            CurrentAmountOfFuel = i_CurrentFuelAmount;
            VehicleWheels = i_Wheels;
            MaximumAmountOfFuel = i_CarMaxFuel;
            TypeOfFuel = i_CarFuelType;
            PercentageOfEnergyRemaining = i_PercentageOfEnergyRemaining;
        }
    }
}
