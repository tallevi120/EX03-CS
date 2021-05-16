namespace Ex03.GarageLogic
{
    using System;

    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaximumAirPressure;

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaximumAirPressure
        {
            get
            {
                return m_MaximumAirPressure;
            }

            set
            {
                m_MaximumAirPressure = value;
            }
        }

        public void InflatingWheels(float i_HowMuchAirToAdd)
        {
            if(i_HowMuchAirToAdd < 0)
            {
                throw new FormatException("Input must be a positive integer");
            }
            if (m_MaximumAirPressure < i_HowMuchAirToAdd + m_CurrentAirPressure)
            {
                throw new ValueOutOfRangeException("Too much air in the wheel", 0, m_MaximumAirPressure);
            }
            CurrentAirPressure += i_HowMuchAirToAdd;
        }

        public Wheel(string i_ManufacturerName, float i_MaxManufacturerAirPressure, float i_CurrentAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            CurrentAirPressure = i_CurrentAirPressure;
            MaximumAirPressure = i_MaxManufacturerAirPressure;
        }
    }
}
