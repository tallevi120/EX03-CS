namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

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
            eColorsForCar i_CarColor, eNumOfDoors i_Doors, float i_CarMaxFuel, eFuelType i_CarFuelType , float i_PercentageOfEnergyRemaining)
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
Car Color: {9}
Number Of Doors: {10}", this.LicenseNumber, this.ModelName, this.TypeOfFuel, this.MaximumAmountOfFuel, this.CurrentAmountOfFuel, 
this.PercentageOfEnergyRemaining, this.VehicleWheels[0].ManufacturerName, this.VehicleWheels[0].MaximumAirPressure, 
this.VehicleWheels[0].CurrentAirPressure, m_CarDetails.Color, m_CarDetails.NumberOfDoors);
        }
    }
}
