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

        public void Refueling(float i_HowMuchFuelToAdd, eFuelType i_TypeOfFuel)
        {

        }
    }
}
