namespace Ex03.GarageLogic
{
    public class Car
    {
        private eColorsForCar m_Color;
        private eNumOfDoors m_NumberOfDoors;

        public eColorsForCar Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        public eNumOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }

        public Car(eColorsForCar i_Color, eNumOfDoors i_NumberOfDoors)
        {
            m_Color = i_Color;
            m_NumberOfDoors = i_NumberOfDoors;
        }
    }
}
