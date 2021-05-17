namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

    public static class VehicleFactory
    {
        private const int k_CarWheelsAmount = 4;
        private const int k_CarMaxManufacturerAirPressure = 32;
        private const eFuelType k_CarFuelType = eFuelType.Octan95;
        private const float k_CarMaxFuel = 45f;
        private const float k_CarMaxElectricPower = 3.2f;

        private const int k_MotorcycleTiresAmount = 2;
        private const float k_MotorcycleMaxFuel = 6f;
        private const eFuelType k_MotorcycleFuelType = eFuelType.Octan98;
        private const int k_MotorcycleMaxManufacturerAirPressure = 30;
        private const float k_MotorcycleMaxElectricPower = 1.8f;

        private const int k_TruckWheelsAmount = 16;
        private const float k_TruckMaxFuel = 120f;
        private const int k_TruckMaxManufacturerAirPressure = 26;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;

        public static FuelCar CreateFuelCar(string i_ModelName, string i_LicenceNumber, eColorsForCar i_CarColor, eNumOfDoors i_Doors,
            string i_ManufacturerWheelName, float i_CurrentWheelAirPressure, float i_CurrentFuelAmount)
        {
            List<Wheel> wheels;
            float PercentageOfEnergyRemaining;

            if(!checkIfValueInRange(0, k_CarMaxFuel, i_CurrentFuelAmount))
            {
                throw new ValueOutOfRangeException("The current fuel amount bigger than the max fuel amount !", 0, k_CarMaxFuel);
            }

            if(!checkIfValueInRange(0, k_CarMaxManufacturerAirPressure, i_CurrentWheelAirPressure))
            {
                throw new ValueOutOfRangeException("The current wheel air pressure bigger than the max air pressure !", 0,
                    k_CarMaxManufacturerAirPressure);
            }

            wheels = createWheels(k_CarWheelsAmount, k_CarMaxManufacturerAirPressure, i_ManufacturerWheelName, i_CurrentWheelAirPressure);
            PercentageOfEnergyRemaining = (100 / k_CarMaxFuel) * i_CurrentFuelAmount;

            return new FuelCar(i_ModelName, i_LicenceNumber, i_CurrentFuelAmount, wheels, i_CarColor, i_Doors, k_CarMaxFuel, k_CarFuelType, 
                PercentageOfEnergyRemaining);
        }

        public static ElectricCar CreateElectricCar(string i_ModelName, string i_LicenceNumber, eColorsForCar i_CarColor,
            eNumOfDoors i_Doors, string i_ManufacturerWheelName, float i_CurrentWheelAirPressure, float i_WorkHoursRemining)
        {
            List<Wheel> wheels;
            float PercentageOfEnergyRemaining;

            if(!checkIfValueInRange(0, k_CarMaxElectricPower, i_WorkHoursRemining))
            {
                throw new ValueOutOfRangeException("The work hours remining bigger than the max electric power !", 0, k_CarMaxElectricPower);
            }

            if(!checkIfValueInRange(0, k_CarMaxManufacturerAirPressure, i_CurrentWheelAirPressure))
            {
                throw new ValueOutOfRangeException("The current wheel air pressure bigger than the max air pressure !", 0,
                    k_CarMaxManufacturerAirPressure);
            }

            wheels = createWheels(k_CarWheelsAmount, k_CarMaxManufacturerAirPressure, i_ManufacturerWheelName,
                i_CurrentWheelAirPressure);
            PercentageOfEnergyRemaining = (100 / k_CarMaxElectricPower) * i_WorkHoursRemining;

            return new ElectricCar(i_ModelName, i_LicenceNumber, wheels, i_CarColor, i_Doors, i_WorkHoursRemining, k_CarMaxElectricPower, 
                PercentageOfEnergyRemaining);
        }

        public static FuelMotorcycle CreateFuelMorotcycle(string i_ModelName, string i_LicenceNumber, eMotorcycleLicenseType i_LicenseType,
            int i_EngineCc, string i_ManufacturerWheelName, float i_CurrentWheelAirPressure, float i_CurrentFuelAmount)
        {
            List<Wheel> wheels;
            float PercentageOfEnergyRemaining;

            if(!checkIfValueInRange(0, k_MotorcycleMaxFuel, i_CurrentFuelAmount))
            {
                throw new ValueOutOfRangeException("The current fuel amount bigger than the max fuel amount !", 0, k_MotorcycleMaxFuel);
            }

            if(!checkIfValueInRange(0, k_MotorcycleMaxManufacturerAirPressure, i_CurrentWheelAirPressure))
            {
                throw new ValueOutOfRangeException("The current wheel air pressure bigger than the max air pressure !", 0,
                    k_MotorcycleMaxManufacturerAirPressure);
            }

            wheels = createWheels(k_MotorcycleTiresAmount, k_MotorcycleMaxManufacturerAirPressure, i_ManufacturerWheelName,
                i_CurrentWheelAirPressure);
            PercentageOfEnergyRemaining = (100 / k_MotorcycleMaxFuel) * i_CurrentFuelAmount;

            return new FuelMotorcycle(i_ModelName, i_LicenceNumber, wheels, i_LicenseType, i_EngineCc, i_CurrentFuelAmount,
                k_MotorcycleMaxFuel, k_MotorcycleFuelType, PercentageOfEnergyRemaining);
        }

        public static ElectricMotorcycle CreateElectricMorotcycle(string i_ModelName, string i_LicenceNumber, 
            eMotorcycleLicenseType i_LicenseType, int i_EngineCc, string i_ManufacturerWheelName, float i_CurrentWheelAirPressure, 
            float i_WorkHoursRemining)
        {
            List<Wheel> wheels;
            float PercentageOfEnergyRemaining;

            if(!checkIfValueInRange(0, k_MotorcycleMaxElectricPower, i_WorkHoursRemining))
            {
                throw new ValueOutOfRangeException("The work hours remining bigger than the max electric power !", 0,
                    k_MotorcycleMaxElectricPower);
            }

            if(!checkIfValueInRange(0, k_MotorcycleMaxManufacturerAirPressure, i_CurrentWheelAirPressure))
            {
                throw new ValueOutOfRangeException("The current wheel air pressure bigger than the max air pressure !", 0,
                    k_MotorcycleMaxManufacturerAirPressure);
            }

            wheels = createWheels(k_MotorcycleTiresAmount, k_MotorcycleMaxManufacturerAirPressure, i_ManufacturerWheelName,
                i_CurrentWheelAirPressure);
            PercentageOfEnergyRemaining = (100 / k_MotorcycleMaxElectricPower) * i_WorkHoursRemining;

            return new ElectricMotorcycle(i_ModelName, i_LicenceNumber, wheels, i_LicenseType, i_EngineCc, i_WorkHoursRemining,
                k_MotorcycleMaxElectricPower, PercentageOfEnergyRemaining);
        }

        public static FuelTruck CreateFuelTruck(string i_ModelName, string i_LicenceNumber, float i_MaxCargoWeightAllowed, 
            string i_ManufacturerWheelName, float i_CurrentWheelAirPressure, float i_CurrentFuelAmount, bool i_IsCarryngDangerousMaterials)
        {
            List<Wheel> wheels;
            float PercentageOfEnergyRemaining;

            if(!checkIfValueInRange(0, k_TruckMaxFuel, i_CurrentFuelAmount))
            {
                throw new ValueOutOfRangeException("The current fuel amount bigger than the max fuel amount !", 0, k_TruckMaxFuel);
            }

            if(!checkIfValueInRange(0, k_TruckMaxManufacturerAirPressure, i_CurrentWheelAirPressure))
            {
                throw new ValueOutOfRangeException("The current wheel air pressure bigger than the max air pressure !", 0,
                    k_TruckMaxManufacturerAirPressure);
            }

            wheels = createWheels(k_TruckWheelsAmount, k_TruckMaxManufacturerAirPressure, i_ManufacturerWheelName, i_CurrentWheelAirPressure);
            PercentageOfEnergyRemaining = (100 / k_TruckMaxFuel) * i_CurrentFuelAmount;

            return new FuelTruck(i_ModelName, i_LicenceNumber, wheels, i_MaxCargoWeightAllowed, i_CurrentFuelAmount, k_TruckMaxFuel,
                i_IsCarryngDangerousMaterials, k_TruckFuelType, PercentageOfEnergyRemaining);
        }

        private static List<Wheel> createWheels(int i_WheelsCount, float i_MaxManufacturerAirPressure, string i_ManufacturerName,
            float i_CurrentAirPressure)
        {
            List<Wheel> wheels = new List<Wheel>();
            for(int wheelIndex = 0; wheelIndex < i_WheelsCount; wheelIndex++)
            {
                wheels.Add(new Wheel(i_ManufacturerName, i_MaxManufacturerAirPressure, i_CurrentAirPressure));
            }

            return wheels;
        }

        private static bool checkIfValueInRange<T>(T i_MinValue, T i_MaxValue, T i_OurValue) where T : System.IComparable<T>
        {
            bool ifInRange = false;

            if(i_OurValue.CompareTo(i_MinValue) >= 0  && i_OurValue.CompareTo(i_MaxValue) <= 0)
            {
                ifInRange = true;
            }

            return ifInRange;
        }
    }
}
