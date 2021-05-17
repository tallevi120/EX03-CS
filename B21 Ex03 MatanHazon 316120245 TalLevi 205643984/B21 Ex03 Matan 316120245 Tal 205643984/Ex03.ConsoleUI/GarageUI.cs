namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic;
    using Ex03.GarageLogic.Enums;

    public class GarageUI
    {
        private const bool k_IsPossitiveNumberOnly = true;
        private Garage m_Garage;

        public Garage Garage
        {
            get
            {
                return m_Garage;
            }

            set
            {
                m_Garage = value;
            }
        }

        public GarageUI()
        {
            Garage = new Garage();
        }

        public void Start()
        {
            const int numOfOptions = 8;
            bool exitProgram = false;

            while(!exitProgram)
            {
                printMainMenu();
                int option = getMenuOptionFromUser(numOfOptions);
                try
                {
                    switch(option)
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
                            exitProgram = true;
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Operation failed");
                    Console.WriteLine(e.Message);
                }

                if(option != 8)
                {
                    pressAnyKeyToContinue();
                }
            }

            Console.WriteLine("Thank you for using garage system!");
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

            while(true)
            {
                try
                {
                    optionFromUser = int.Parse(Console.ReadLine());
                    if(optionFromUser >= 1 && optionFromUser <= i_NumOfOptions)
                    {
                        break;
                    }

                    Console.WriteLine("Invalid input, Please choose number between 1 to {0} only.", i_NumOfOptions);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Bad input, Please use integers only");
                }
            }

            return optionFromUser;
        }

        private int getIntFromUser(bool i_IsPossitiveOnly)
        {
            int optionFromUser;

            while(!int.TryParse(Console.ReadLine(), out optionFromUser) || (optionFromUser < 0 || !i_IsPossitiveOnly))
            {
                Console.WriteLine("Invalid input, Please enter a {0}number only.", i_IsPossitiveOnly ? "possitive " : string.Empty);
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
            stringBuilder.AppendLine(" 3.Change the vehicle status.");
            stringBuilder.AppendLine(" 4.Inflating vehicle's wheels.");
            stringBuilder.AppendLine(" 5.Refueling your vehicle.");
            stringBuilder.AppendLine(" 6.Recharge your electric vehicle.");
            stringBuilder.AppendLine(" 7.Show full report about your vehicle by licence number.");
            stringBuilder.AppendLine(" 8.Exit.");
            Console.WriteLine(stringBuilder);
        }

        private void insertVehicleToGarage()
        {
            string licenseNumber = getLicenseNumberFromUser();
            bool isInGarage = Garage.IfVehicleExists(licenseNumber);

            if(!isInGarage)
            {
                Console.WriteLine("Your car is not in the garage. Enter your car's details to insert.");
                Console.WriteLine();
                insertNewVehicleToGarage(licenseNumber);
            }
            else
            {
                Console.WriteLine("Vehicle Already in the garage!!");
            }
        }

        private string getLicenseNumberFromUser()
        {
            Console.WriteLine("Please enter your car's licence number");

            return Console.ReadLine();
        }

        private void insertNewVehicleToGarage(string i_LicenceNumber)
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

                switch(vehicleType)
                {
                    case eVehicleType.FuelMotorcycle:
                        motorcycleLicenseType = getMotorcycleLicenseTypeFromUser();
                        motorcycleEngineSize = getMotorcycleCcFromUser();
                        currentFuelAmmount = getCurrentFuelAmountFromUser();
                        vehicle = VehicleFactory.CreateFuelMorotcycle(vehicleModel, i_LicenceNumber, motorcycleLicenseType, 
                            motorcycleEngineSize, wheelsManufaturer, currentWheelAirPreasure, currentFuelAmmount);
                        break;

                    case eVehicleType.ElectricMotorcycle:
                        motorcycleLicenseType = getMotorcycleLicenseTypeFromUser();
                        motorcycleEngineSize = getMotorcycleCcFromUser();
                        currentEnergyLeft = getCurrentEnergyLeftFromUser();
                        vehicle = VehicleFactory.CreateElectricMorotcycle(vehicleModel, i_LicenceNumber, motorcycleLicenseType, 
                            motorcycleEngineSize, wheelsManufaturer, currentWheelAirPreasure, currentEnergyLeft);
                        break;

                    case eVehicleType.FuelCar:
                        carColor = getColorTypeFromUser();
                        numOfDoors = getNumOfDoorsFromUser();
                        currentFuelAmmount = getCurrentFuelAmountFromUser();
                        vehicle = VehicleFactory.CreateFuelCar(vehicleModel, i_LicenceNumber, carColor, numOfDoors, wheelsManufaturer, 
                            currentWheelAirPreasure, currentFuelAmmount);
                        break;

                    case eVehicleType.ElectricCar:
                        carColor = getColorTypeFromUser();
                        numOfDoors = getNumOfDoorsFromUser();
                        currentEnergyLeft = getCurrentEnergyLeftFromUser();
                        vehicle = VehicleFactory.CreateElectricCar(vehicleModel, i_LicenceNumber, carColor, numOfDoors, wheelsManufaturer,
                            currentWheelAirPreasure, currentEnergyLeft);
                        break;

                    case eVehicleType.FuelTruck:
                        var isCarryngDangerousMaterials = getIsCarryingDangerousMaterialsFromUser();
                        var maxCargoWeight = getMaxCargoCargoWeightFromUser();
                        currentFuelAmmount = getCurrentFuelAmountFromUser();
                        vehicle = VehicleFactory.CreateFuelTruck(vehicleModel, i_LicenceNumber, maxCargoWeight, wheelsManufaturer, 
                            currentWheelAirPreasure, currentFuelAmmount, isCarryngDangerousMaterials);
                        break;

                    default:
                        throw new ArgumentException("not a vehicle availble at the menu");
                }

                vehicleToAdd.Vehicle = vehicle;
                vehicleToAdd.OwnerName = ownerName;
                vehicleToAdd.OwnerPhone = ownerPhone;
                Garage.InsertVehicleIntoGarage(vehicleToAdd);
                Console.WriteLine("Your vehicle has been inserted to the garage!");
            }
            catch(ArgumentException ax)
            {
                Console.WriteLine("Operation Failed - bad argument");
                Console.WriteLine(ax.Message);
            }
            catch(ValueOutOfRangeException voore)
            {
                Console.WriteLine("Operation Failed - bad value entered");
                Console.WriteLine(voore.Message);
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

            return getFloatFromUser(k_IsPossitiveNumberOnly);
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

            return getFloatFromUser(k_IsPossitiveNumberOnly);
        }

        private float getCurrentFuelAmountFromUser()
        {
            Console.WriteLine("How much fuel do you have? (Liters)");

            return getFloatFromUser(k_IsPossitiveNumberOnly);
        }

        private bool getIsCarryingDangerousMaterialsFromUser()
        {
            Console.WriteLine("Is your truck carring dangerous materials?");

            return getBoolFromUser();
        }

        private float getMaxCargoCargoWeightFromUser()
        {
            Console.WriteLine("What is your Max cargo weight? (KG)");

            return getFloatFromUser(k_IsPossitiveNumberOnly);
        }

        private eNumOfDoors getNumOfDoorsFromUser()
        {
            const int numOfOptions = 4;
            int option;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("How many doors do you have?");
            stringBuilder.AppendLine(" 1.Two.");
            stringBuilder.AppendLine(" 2.Three.");
            stringBuilder.AppendLine(" 3.Four.");
            stringBuilder.AppendLine(" 4.Five.");
            Console.WriteLine(stringBuilder);
            option = getMenuOptionFromUser(numOfOptions);

            return (eNumOfDoors)option;
        }

        private bool getBoolFromUser()
        {
            const int numOfOptions = 2;
            bool isTrue = true;
            int result;

            Console.WriteLine(" 1.Yes.");
            Console.WriteLine(" 2.No.");
            result = getMenuOptionFromUser(numOfOptions);

            if(result == 2)
            {
                isTrue = false;
            }

            return isTrue;
        }

        private eMotorcycleLicenseType getMotorcycleLicenseTypeFromUser()
        {
            const int numOfMotorcycleLicenseTypes = 4;
            int option;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is the motorcycle license type?");
            stringBuilder.AppendLine(" 1. A.");
            stringBuilder.AppendLine(" 2. B1.");
            stringBuilder.AppendLine(" 3. AA.");
            stringBuilder.AppendLine(" 4. BB.");
            Console.WriteLine(stringBuilder);
            option = getMenuOptionFromUser(numOfMotorcycleLicenseTypes);

            return (eMotorcycleLicenseType)option;
        }

        private int getMotorcycleCcFromUser()
        {
            Console.WriteLine("What is the motorcycle engine size? (CC)");

            return getIntFromUser(k_IsPossitiveNumberOnly);
        }

        private eVehicleType getVehicleTypeFromUser()
        {
            const int numOfOptions = 5;
            int option;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is your vehicle type?");
            stringBuilder.AppendLine(" 1.Fuel MotorCycle.");
            stringBuilder.AppendLine(" 2.Electric MotorCycle.");
            stringBuilder.AppendLine(" 3.Fuel Car.");
            stringBuilder.AppendLine(" 4.Electric Car.");
            stringBuilder.AppendLine(" 5.Fuel Truck.");
            Console.WriteLine(stringBuilder);
            option = getMenuOptionFromUser(numOfOptions);

            return (eVehicleType)option;
        }

        private eColorsForCar getColorTypeFromUser()
        {
            const int numOfOptions = 4;
            int option;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is your vehicle Color?");
            stringBuilder.AppendLine(" 1. Red.");
            stringBuilder.AppendLine(" 2. Silver.");
            stringBuilder.AppendLine(" 3. White.");
            stringBuilder.AppendLine(" 4. Black.");
            Console.WriteLine(stringBuilder);
            option = getMenuOptionFromUser(numOfOptions);

            return (eColorsForCar)option;
        }

        private void vehicleLicenseNumbersMenu()
        {
            const int numOfOptions = 3;
            int option;

            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Please choose what would you like to do:");
            stringBuilder.AppendLine("----------------------------------------");
            stringBuilder.AppendLine(" 1. Show all vehicles in the garage.");
            stringBuilder.AppendLine(" 2. Show vehicles in the garage filtered by status.");
            stringBuilder.AppendLine(" 3. Back to previous menu");
            Console.WriteLine(stringBuilder);
            option = getMenuOptionFromUser(numOfOptions);
            switch(option)
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
            if(licenseNumbers != null)
            {
                foreach(string licenseNumber in licenseNumbers)
                {
                    counter++;
                    Console.WriteLine("{0}. {1}.", counter, licenseNumber);
                }
            }
        }

        private void filteredVehicleLicenseNumbersMenu()
        {
            const int numOfOptions = 3;
            int optionFromUser;

            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("By What status do you want to Filter:");
            stringBuilder.AppendLine("-----------------------------------");
            stringBuilder.AppendLine(" 1. InRepair.");
            stringBuilder.AppendLine(" 2. Fixed.");
            stringBuilder.AppendLine(" 3. PaidUp.");
            Console.Write(stringBuilder);

            optionFromUser = getMenuOptionFromUser(numOfOptions);
            switch(optionFromUser)
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
            string licenseNumber;

            Console.WriteLine("You are about to update vehicle status");
            licenseNumber = getLicenseNumberFromUser();
            if(Garage.IfVehicleExists(licenseNumber))
            {
                Console.WriteLine();
                Console.WriteLine("Please choose the new status:");
                Console.WriteLine(" 1. InRepair.");
                Console.WriteLine(" 2. Fixed.");
                Console.WriteLine(" 3. PaidUp.");
                int option = getMenuOptionFromUser(numOfOptions);
                try
                {
                    switch(option)
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
                catch(ArgumentException ae)
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
            string licenseNumber;

            Console.WriteLine();
            Console.WriteLine("You are about to fill your vehicle wheels:");
            licenseNumber = getLicenseNumberFromUser();
            if(Garage.IfVehicleExists(licenseNumber))
            {
                try
                {
                    Garage.InflatingWheelsToMax(licenseNumber);
                    Console.WriteLine("GREAT SUCCESS!");
                }
                catch(ArgumentException ae)
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
            int option;

            Console.WriteLine(" 1. Soler.");
            Console.WriteLine(" 2. Octan95.");
            Console.WriteLine(" 3. Octan96.");
            Console.WriteLine(" 4. Octan98.");

            option = getMenuOptionFromUser(numOfOptions);

            return (eFuelType)option;
        }

        private void fuelVehicle()
        {
            string licenseNumber;

            Console.WriteLine();
            Console.WriteLine("You are about to fuel your vehicle:");
            licenseNumber = getLicenseNumberFromUser();
            if(Garage.IfVehicleExists(licenseNumber))
            {
                eFuelType fuelType;
                float amountToFuel;

                Console.WriteLine();
                Console.WriteLine("Please choose fuel type:");
                fuelType = getFuelTypeFromUser();
                Console.WriteLine("Please enter the amount to fuel:");
                amountToFuel = getFloatFromUser(k_IsPossitiveNumberOnly);
                try
                {
                    Garage.Refueling(licenseNumber, fuelType, amountToFuel);
                    Console.WriteLine("GREAT SUCCESS!");
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine("Operation failed");
                    Console.WriteLine(ae.Message);
                }
                catch(ValueOutOfRangeException voore)
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

            while(!float.TryParse(Console.ReadLine(), out optionFromUser) || (optionFromUser < 0 || !i_IsPossitiveOnly))
            {
                Console.WriteLine("Invalid input, Please choose floating point {0}number only.", i_IsPossitiveOnly ? "possitive " : string.Empty);
            }

            return optionFromUser;
        }

        private void chargeVehicle()
        {
            string licenseNumber;
            Console.WriteLine();
            Console.WriteLine("You are about to charge your vehicle:");
            licenseNumber = getLicenseNumberFromUser();
            if(Garage.IfVehicleExists(licenseNumber))
            {
                float hoursToCharge;

                Console.WriteLine("For how many hours would you like to charge? ");
                hoursToCharge = getFloatFromUser(k_IsPossitiveNumberOnly);
                try
                {
                    Garage.BatteryCharging(licenseNumber, hoursToCharge);
                    Console.WriteLine("GREAT SUCCESS!");
                }
                catch(ValueOutOfRangeException voore)
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
            string licenseNumber;

            Console.WriteLine();
            Console.WriteLine("You are about to show cars report:");
            licenseNumber = getLicenseNumberFromUser();
            if(Garage.IfVehicleExists(licenseNumber))
            {
                try
                {
                    Console.Clear();
                    string carReport = Garage.DetailsAboutVehicle(licenseNumber);
                    Console.WriteLine(carReport);
                }
                catch(ArgumentException ae)
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
            foreach(string licenseNumber in Garage.ShowLicenseNumbersWithSameStatus(i_FilteredBy))
            {
                counter++;
                Console.WriteLine("{0}. {1}.", counter, licenseNumber);
            }
        }
    }
}