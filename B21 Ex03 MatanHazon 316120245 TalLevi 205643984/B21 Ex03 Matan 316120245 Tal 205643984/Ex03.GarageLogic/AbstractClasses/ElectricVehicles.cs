using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicles : Vehicle
    {
        private float m_RemainingBatteryTime;
        private float m_MaximumBatteryTime;

        public void BatteryCharging(float i_AmountOfChargingHours)
        {

        }
    }
}
