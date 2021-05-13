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

        }
    }
}
