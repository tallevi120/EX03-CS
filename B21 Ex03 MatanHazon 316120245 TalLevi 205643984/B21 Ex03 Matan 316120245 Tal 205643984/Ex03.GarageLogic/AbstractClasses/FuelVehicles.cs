using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
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
            if(m_MaximumAmountOfFuel <= i_HowMuchFuelToAdd + m_CurrentAmountOfFuel)
            {
                return;
            }

            m_CurrentAmountOfFuel += i_HowMuchFuelToAdd;
        }

    }
}
