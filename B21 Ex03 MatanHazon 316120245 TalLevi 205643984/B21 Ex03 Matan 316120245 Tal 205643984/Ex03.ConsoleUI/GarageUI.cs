namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic;
    using Ex03.GarageLogic.Enums;
    public class GarageUI
    {
        private const bool v_IsPossitiveNumberOnly = true;
        private Garage Garage { get; set; }

        public GarageUI()
        {
            Garage = new Garage();
        }

        public void Start()
        {
            const int numOfOptions = 8;

            bool shouldExit = false;
            while (!shouldExit)
            {
                printMainMenu();
                int option = getMenuOptionFromUser(numOfOptions);
                try
                {
                    switch (option)
                    {
                        case 1:
                            insertVehicleToGarage();
                            break;
                        case 2:
                            vehicleLicenseNumbersMenu();
                            break;
                        case 3:
                            updateVehicleState();
                            break;
                        case 4:
                            fillAirPresure();
                            break;
                        case 5:
                            fuelVehicle();
                            break;
                        case 6:
                            chargeVehicle();
                            break;
                        case 7:
                            showVehicleReport();
                            break;
                        case 8:
                            shouldExit = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Operation failed");
                    Console.WriteLine(e.Message);
                }

                if (option != 8)
                {
                    pressAnyKeyToContinue();
                }
            }

            Console.WriteLine("Thanks for using garage system!");
            pressAnyKeyToContinue();
        }

        private void pressAnyKeyToContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private int getMenuOptionFromUser(int i_NumOfOptions)
        {
            int optionFromUser;

            while (true)
            {
                try
                {
                    optionFromUser = int.Parse(Console.ReadLine());
                    if (optionFromUser >= 1 && optionFromUser <= i_NumOfOptions)
                    {
                        break;
                    }

                    Console.WriteLine("Invalid input, Please choose number between 1 to {0} only.", i_NumOfOptions);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad input, Please use integers only");
                }
            }

            return optionFromUser;
        }

        private int getMenuOptionFromUserWithTryParse(int i_NumOfOptions)
        {
            int optionFromUser;

            while (!int.TryParse(Console.ReadLine(), out optionFromUser) || optionFromUser < 1 || optionFromUser > i_NumOfOptions)
            {
                Console.WriteLine("Invalid input, Please choose number between 1 to {0} only.", i_NumOfOptions);
            }

            return optionFromUser;
        }

        private int getIntFromUser(bool i_IsPossitiveOnly)
        {
            int optionFromUser;

            while (!int.TryParse(Console.ReadLine(), out optionFromUser) || (optionFromUser < 0 || !i_IsPossitiveOnly))
            {
                Console.WriteLine("Invalid input, Please enter a {0}number only.", i_IsPossitiveOnly ? "possitive " : "");
            }

            return optionFromUser;
        }

        private void printMainMenu()
        {
            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Please choose option:");
            stringBuilder.AppendLine("--------------------");
            stringBuilder.AppendLine(" 1.Insert a new vehicle to the Garage.");
            stringBuilder.AppendLine(" 2.Show a list of Vehicles in the garage.");
            stringBuilder.AppendLine(" 3.Change the vehicle state.");
            stringBuilder.AppendLine(" 4.Inflating vehicle's wheels.");
            stringBuilder.AppendLine(" 5.Refueling your vehicle.");
            stringBuilder.AppendLine(" 6.Recharge your electric vehicle.");
            stringBuilder.AppendLine(" 7.Show full report about your vehicle by licence number.");
            stringBuilder.AppendLine(" 8.Exit.");
            Console.WriteLine(stringBuilder);
        }

        private void insertVehicleToGarage()
        {
            string licensePlate = getLicenseNumberFromUser();
            bool isInGarage = Garage.IfVehicleExists(licensePlate);
            if (!isInGarage)
            {
                Console.WriteLine("Your car is not in the garage. Enter your car's details to insert.");
                Console.WriteLine();

                insertNewVehicleToGarage(licensePlate);
            }
            else
            {
                Console.WriteLine("Vehicle Already in the garage!!");
            }
        }

        private string getLicenseNumberFromUser()
        {
            Console.WriteLine("Please enter your car's licence plate");

            return Console.ReadLine();
        }

        private void insertNewVehicleToGarage(string i_LicencePlate)
        {
            try
            {
                int motorcycleEngineSize;
                float currentEnergyLeft;
                float currentFuelAmmount;
                eColorsForCar carColor;
                eNumOfDoors numOfDoors;
                eMotorcycleLicenseType motorcycleLicenseType;

                eVehicleType vehicleType = getVehicleTypeFromUser();
                string ownerPhone = getOwnerPhoneFromUser();
                string vehicleModel = getVehicleModelFromUser();
                string wheelsManufaturer = getWheelManufactorerFromUser();
                float currentWheelAirPreasure = getCurrentWheelAirPressureFromUser();
                string ownerName = getOwnerNameFromUser();
                Vehicle vehicle;
                VehicleInTheGarage vehicleToAdd = new VehicleInTheGarage();

                switch (vehicleType)
                {
                    case eVehicleType.FuelMotorcycle:
                        motorcycleLicenseType = getMotorcycleLicenseTypeFromUser();
                        motorcycleEngineSize = getMotorcycleCcFromUser();
                        currentFuelAmmount = getCurrentFuelAmountFromUser();
                        vehicle = VehicleFactory.GenerateFuelMorotcycle(vehicleModel, i_LicencePlate, motorcycleLicenseType, 
                            motorcycleEngineSize, wheelsManufaturer, currentWheelAirPreasure, currentFuelAmmount);
                        break;

                    case eVehicleType.ElectricMotorcycle:
                        motorcycleLicenseType = getMotorcycleLicenseTypeFromUser();
                        motorcycleEngineSize = getMotorcycleCcFromUser();
                        currentEnergyLeft = getCurrentEnergyLeftFromUser();
                        vehicle = VehicleFactory.GenerateElectricMorotcycle(vehicleModel, i_LicencePlate, motorcycleLicenseType, 
                            motorcycleEngineSize, wheelsManufaturer, currentWheelAirPreasure, currentEnergyLeft);
                        break;

                    case eVehicleType.FuelCar:
                        carColor = getColorTypeFromUser();
                        numOfDoors = getNumOfDoorsFromUser();
                        currentFuelAmmount = getCurrentFuelAmountFromUser();
                        vehicle = VehicleFactory.GenerateFuelCar(vehicleModel, i_LicencePlate, carColor, numOfDoors, wheelsManufaturer, 
                            currentWheelAirPreasure, currentFuelAmmount);
                        break;

                    case eVehicleType.ElectricCar:
                        carColor = getColorTypeFromUser();
                        numOfDoors = getNumOfDoorsFromUser();
                        currentEnergyLeft = getCurrentEnergyLeftFromUser();
                        vehicle = VehicleFactory.GenerateElectricCar(vehicleModel, i_LicencePlate, carColor, numOfDoors, wheelsManufaturer,
                            currentWheelAirPreasure, currentEnergyLeft);
                        break;

                    case eVehicleType.FuelTruck:
                        var isCarryngDangerousMaterials = getIsCarryingDangerousMaterialsFromUser();
                        var maxCargoWeight = getMaxCargoCargoWeightFromUser();
                        currentFuelAmmount = getCurrentFuelAmountFromUser();
                        vehicle = VehicleFactory.GenerateTruck(vehicleModel, i_LicencePlate, maxCargoWeight, wheelsManufaturer, 
                            currentWheelAirPreasure, currentFuelAmmount, isCarryngDangerousMaterials);
                        break;

                    default:
                        throw new ArgumentException("not a vehicle availble at the menu");
                }
                vehicleToAdd.Vehicle = vehicle;
                vehicleToAdd.OwnerName = ownerName;
                vehicleToAdd.OwnerPhone = ownerPhone;
                Garage.InsertVehicleIntoGarage(vehicleToAdd);
                Console.WriteLine("your vehicle had been inserted to the garage!");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine("Operation Failed - bad argument");
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.WriteLine("Operation Failed - bad value entered");
            }
        }

        private string getOwnerPhoneFromUser()
        {
            Console.Write("Please enter your phone number:  ");

            return Console.ReadLine();
        }

        private string getOwnerNameFromUser()
        {
            Console.Write("Please enter your name:  ");

            return Console.ReadLine();
        }

        private float getCurrentWheelAirPressureFromUser()
        {
            Console.Write("Please enter your vehicle's wheels current air pressure:  ");

            return getFloatFromUser(v_IsPossitiveNumberOnly);
        }

        private string getWheelManufactorerFromUser()
        {
            Console.Write("Please enter your vehicle's wheels Manufactirer:  ");

            return Console.ReadLine();
        }

        private string getVehicleModelFromUser()
        {
            Console.Write("Please enter your vehicle's model:  ");

            return Console.ReadLine();
        }

        private float getCurrentEnergyLeftFromUser()
        {
            Console.WriteLine("How many hours left in your Engine's battary?");

            return getFloatFromUser(v_IsPossitiveNumberOnly);
        }

        private float getCurrentFuelAmountFromUser()
        {
            Console.WriteLine("How much fuel do you have? (Liters)");

            return getFloatFromUser(v_IsPossitiveNumberOnly);
        }

        private bool getIsCarryingDangerousMaterialsFromUser()
        {
            Console.WriteLine("Is your truck carring dangerous materials?");

            return getBoolFromUser();
        }

        private float getMaxCargoCargoWeightFromUser()
        {
            Console.WriteLine("What is your Max cargo weight?");

            return getFloatFromUser(v_IsPossitiveNumberOnly);
        }

        private eNumOfDoors getNumOfDoorsFromUser()
        {
            const int numOfOptions = 4;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("How many doors do you have?");
            stringBuilder.AppendLine(" 1.Two.");
            stringBuilder.AppendLine(" 2.Three.");
            stringBuilder.AppendLine(" 3.Four.");
            stringBuilder.AppendLine(" 4.Five.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(numOfOptions);

            return (eNumOfDoors)option;
        }


        private bool getBoolFromUser()
        {
            const int numOfOptions = 2;
            bool isTrue = true;

            Console.WriteLine(" 1.Yes.");
            Console.WriteLine(" 2.No.");

            int result = getMenuOptionFromUser(numOfOptions);
            if (result == 2)
            {
                isTrue = false;
            }

            return isTrue;
        }

        private eMotorcycleLicenseType getMotorcycleLicenseTypeFromUser()
        {
            const int numOfMotorcycleLicenseTypes = 4;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is the motorcycle license type type?");
            stringBuilder.AppendLine(" 1. A.");
            stringBuilder.AppendLine(" 2. B1.");
            stringBuilder.AppendLine(" 3. AA.");
            stringBuilder.AppendLine(" 4. BB.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(numOfMotorcycleLicenseTypes);

            return (eMotorcycleLicenseType)option;
        }

        private int getMotorcycleCcFromUser()
        {
            Console.WriteLine("What is the motorcycle engine size (CC)?");

            return getIntFromUser(v_IsPossitiveNumberOnly);
        }

        private eVehicleType getVehicleTypeFromUser()
        {
            const int numOfOptions = 5;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is your vehicle type?");
            stringBuilder.AppendLine(" 1.Fuel MotorCycle.");
            stringBuilder.AppendLine(" 2.Electric MotorCycle.");
            stringBuilder.AppendLine(" 3.Fuel Car.");
            stringBuilder.AppendLine(" 4.Electric Car.");
            stringBuilder.AppendLine(" 5.Fuel Truck.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(numOfOptions);

            return (eVehicleType)option;
        }

        private eColorsForCar getColorTypeFromUser()
        {
            const int numOfOptions = 4;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is your vehicle Color?");
            stringBuilder.AppendLine(" 1. Red.");
            stringBuilder.AppendLine(" 2. Silver.");
            stringBuilder.AppendLine(" 3. White.");
            stringBuilder.AppendLine(" 4. Black.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(numOfOptions);

            return (eColorsForCar)option;
        }

        private void vehicleLicenseNumbersMenu()
        {
            const int numOfOptions = 3;

            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Please choose what would you like to do:");
            stringBuilder.AppendLine("----------------------------------------");
            stringBuilder.AppendLine(" 1. Show all vehicles in the garage.");
            stringBuilder.AppendLine(" 2. Show vehicles in the garage filtered by status.");
            stringBuilder.AppendLine(" 3. Back to previous menu");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(numOfOptions);

            switch (option)
            {
                case 1:
                    showAllVechaleLicenseNumbers();
                    break;
                case 2:
                    filteredVehicleLicenseNumbersMenu();
                    break;
                case 3:
                    break;
            }
        }


        private void showAllVechaleLicenseNumbers()
        {
            int counter = 0;
            List<string> licenseNumbers = Garage.ShowAllLicenseNumbers();

            Console.Clear();
            Console.WriteLine("List of vehicles:");
            Console.WriteLine("-----------------");
            if (licenseNumbers != null)
            {
                foreach (string licenseNumber in licenseNumbers)
                {
                    counter++;
                    Console.WriteLine("{0}. {1}.", counter, licenseNumber);
                }
            }
        }

        private void filteredVehicleLicenseNumbersMenu()
        {
            const int numOfOptions = 3;

            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("by What State do you want to Filter:");
            stringBuilder.AppendLine("-----------------------------------");
            stringBuilder.AppendLine(" 1. InRepair.");
            stringBuilder.AppendLine(" 2. Fixed.");
            stringBuilder.AppendLine(" 3. PaidUp.");
            Console.Write(stringBuilder);

            int optionFromUser = getMenuOptionFromUser(numOfOptions);
            switch (optionFromUser)
            {
                case 1:
                    showFilteredListOfLicenseNumbers(eVehicleStatus.InRepair);
                    break;
                case 2:
                    showFilteredListOfLicenseNumbers(eVehicleStatus.Fixed);
                    break;
                case 3:
                    showFilteredListOfLicenseNumbers(eVehicleStatus.PaidUp);
                    break;
            }
        }

        private void updateVehicleState()
        {
            const int numOfOptions = 3;

            Console.WriteLine("You are about to update vehicle state");
            string licenseNumber = getLicenseNumberFromUser();
            if (Garage.IfVehicleExists(licenseNumber))
            {
                Console.WriteLine();
                Console.WriteLine("Please Choose the new status:");
                Console.WriteLine(" 1. InRepair.");
                Console.WriteLine(" 2. Fixed.");
                Console.WriteLine(" 3. PaidUp.");
                int option = getMenuOptionFromUser(numOfOptions);
                try
                {
                    switch (option)
                    {
                        case 1:
                            Garage.ChangeStatus(licenseNumber, eVehicleStatus.InRepair);
                            break;
                        case 2:
                            Garage.ChangeStatus(licenseNumber, eVehicleStatus.Fixed);
                            break;
                        case 3:
                            Garage.ChangeStatus(licenseNumber, eVehicleStatus.PaidUp);
                            break;
                    }
                    Console.WriteLine("Status for vehicle {0} updated", licenseNumber);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Operation failed");
                    Console.WriteLine(ae.Message);
                }
            }
            else
            {
                Console.WriteLine("Vehicle does not exists");
            }
        }

        private void fillAirPresure()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to fill your vehicle tires:");

            string licenseNumber = getLicenseNumberFromUser();
            if (Garage.IfVehicleExists(licenseNumber))
            {
                try
                {
                    Garage.InflatingWheelsToMax(licenseNumber);
                    Console.WriteLine("GREAT SUCCESS!");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Operation failed");
                    Console.WriteLine(ae.Message);
                }
            }
            else
            {
                Console.WriteLine("Vehicle does not exists");
            }

        }

        private eFuelType getFuelTypeFromUser()
        {
            const int numOfOptions = 4;

            Console.WriteLine(" 1. Soler.");
            Console.WriteLine(" 2. Octan95.");
            Console.WriteLine(" 3. Octan96.");
            Console.WriteLine(" 4. Octan98.");

            int option = getMenuOptionFromUser(numOfOptions);

            return (eFuelType)option;
        }

        private void fuelVehicle()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to fuel your vehicle:");
            string licenseNumber = getLicenseNumberFromUser();
            if (Garage.IfVehicleExists(licenseNumber))
            {
                Console.WriteLine();
                Console.WriteLine("Please Choose fuel type:");
                eFuelType fuelType = getFuelTypeFromUser();

                Console.WriteLine("Please enter the amount to fuel:");
                float amountToFuel = getFloatFromUser(v_IsPossitiveNumberOnly);

                try
                {
                    Garage.Refueling(licenseNumber, fuelType, amountToFuel);
                    Console.WriteLine("GREAT SUCCESS!");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Operation failed");
                    Console.WriteLine(ae.Message);
                }
                catch (ValueOutOfRangeException voore)
                {
                    Console.WriteLine("Operation failed");
                    Console.WriteLine(voore.Message);
                }
            }
            else
            {
                Console.WriteLine("Vehicle does not exists");
            }
        }

        private float getFloatFromUser(bool i_IsPossitiveOnly)
        {
            float optionFromUser;

            while (!float.TryParse(Console.ReadLine(), out optionFromUser) || (optionFromUser < 0 || !i_IsPossitiveOnly))
            {
                Console.WriteLine("Invalid input, Please choose floating point {0}number only.", i_IsPossitiveOnly ? "possitive " : "");
            }

            return optionFromUser;
        }

        private void chargeVehicle()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to charge your vehicle:");
            string licenseNumber = getLicenseNumberFromUser();
            if (Garage.IfVehicleExists(licenseNumber))
            {
                Console.WriteLine("for how many hours would you like to charge? ");
                float hoursToCharge = getFloatFromUser(v_IsPossitiveNumberOnly);

                try
                {
                    Garage.BatteryCharging(licenseNumber, hoursToCharge);
                    Console.WriteLine("GREAT SUCCESS!");
                }
                catch (ValueOutOfRangeException voore)
                {
                    Console.WriteLine("Operation failed");
                    Console.WriteLine(voore.Message);
                }
            }
            else
            {
                Console.WriteLine("Vehicle does not exists");
            }
        }

        private void showVehicleReport()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to show Cars Report:");
            string licenseNumber = getLicenseNumberFromUser();
            if (Garage.IfVehicleExists(licenseNumber))
            {
                try
                {
                    Console.Clear();
                    string carReport = Garage.DetailsAboutVehicle(licenseNumber);
                    Console.WriteLine(carReport);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Operation failed");
                    Console.WriteLine(ae.Message);
                }
            }
            else
            {
                Console.WriteLine("Vehicle does not exists");
            }
        }

        private void showFilteredListOfLicenseNumbers(eVehicleStatus i_FilteredBy)
        {
            int counter = 0;
            Console.Clear();
            Console.WriteLine("List of vehicles:");
            Console.WriteLine("-----------------");
            foreach (string licenseNumber in Garage.ShowLicenseNumbersWithSameStatus(i_FilteredBy))
            {
                counter++;
                Console.WriteLine("{0}. {1}.", counter, licenseNumber);
            }
        }
    }
}

