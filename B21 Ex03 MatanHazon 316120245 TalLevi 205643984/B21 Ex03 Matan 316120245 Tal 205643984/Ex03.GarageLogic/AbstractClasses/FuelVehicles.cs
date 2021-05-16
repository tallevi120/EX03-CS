namespace Ex03.GarageLogic
{
    using System;

    public abstract class FuelVehicles : Vehicle
    {
        private eFuelType m_TypeOfFuel;
        private float m_CurrentAmountOfFuel;
        private float m_MaximumAmountOfFuel;

        public eFuelType TypeOfFuel
        {
            get
            {
                return m_TypeOfFuel;
            }

            set
            {
                m_TypeOfFuel = value;
            }
        }

        public float CurrentAmountOfFuel
        {
            get
            {
                return m_CurrentAmountOfFuel;
            }

            set
            {
                m_CurrentAmountOfFuel = value;
            }
        }

        public float MaximumAmountOfFuel
        {
            get
            {
                return m_MaximumAmountOfFuel;
            }

            set
            {
                m_MaximumAmountOfFuel = value;
            }
        }

        public void Refueling(float i_HowMuchFuelToAdd, eFuelType i_TypeOfFuel)
        {
            if (i_TypeOfFuel != this.m_TypeOfFuel)
            {
                throw new ArgumentException("The type of fuel not valid");
            }
            if (m_MaximumAmountOfFuel < i_HowMuchFuelToAdd + m_CurrentAmountOfFuel)
            {
                throw new ValueOutOfRangeException("Too much fuel in the vehicle", 0, m_MaximumAmountOfFuel);
            }

            m_CurrentAmountOfFuel += i_HowMuchFuelToAdd;
            this.PercentageOfEnergyRemaining = (100 / m_MaximumAmountOfFuel) * m_CurrentAmountOfFuel;
        }

    }
}
