namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicles : Vehicle
    {
        private float m_RemainingBatteryTime;
        private float m_MaximumBatteryTime;

        public float RemainingBatteryTime
        {
            get
            {
                return m_RemainingBatteryTime;
            }

            set
            {
                m_RemainingBatteryTime = value;
            }
        }

        public float MaximumBatteryTime
        {
            get
            {
                return m_MaximumBatteryTime;
            }

            set
            {
                m_MaximumBatteryTime = value;
            }
        }

        public void BatteryCharging(float i_AmountOfChargingHours)
        {
            if(m_MaximumBatteryTime < i_AmountOfChargingHours + m_RemainingBatteryTime)
            {
                throw new ValueOutOfRangeException("Too much hours in the electric vehicle", 0, m_MaximumBatteryTime);
            }

            m_RemainingBatteryTime += i_AmountOfChargingHours;
            this.PercentageOfEnergyRemaining = (100 / m_MaximumBatteryTime) * m_RemainingBatteryTime;
        }
    }
}
