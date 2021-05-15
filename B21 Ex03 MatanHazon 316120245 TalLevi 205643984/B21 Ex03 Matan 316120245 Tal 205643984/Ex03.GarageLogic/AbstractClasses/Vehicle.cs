using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle : VehicleInTheGarage
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_PercentageOfEnergyRemaining;
        private List<Wheel> m_VehicleWheels;

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        public float PercentageOfEnergyRemaining
        {
            get
            {
                return m_PercentageOfEnergyRemaining;
            }

            set
            {
                m_PercentageOfEnergyRemaining = value;
            }
        }

        public List<Wheel> VehicleWheels
        {
            get
            {
                return m_VehicleWheels;
            }

            set
            {
                m_VehicleWheels = value;
            }
        }
    }
}
