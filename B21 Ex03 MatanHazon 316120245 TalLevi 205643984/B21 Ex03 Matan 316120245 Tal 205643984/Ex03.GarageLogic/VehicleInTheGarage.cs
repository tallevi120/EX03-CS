using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInTheGarage
    {
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eVehicleStatus m_VehicleStatus;

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                m_OwnerName = value;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
            }

            set
            {
                m_OwnerPhone = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }
    }
}