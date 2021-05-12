﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_PercentageOfEnergyRemaining;
        private List<Wheel> m_VehicleWheels;
    }
}
