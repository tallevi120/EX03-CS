namespace Ex03.GarageLogic
{
    public class Motorcycle
    {
        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(eMotorcycleLicenseType licenseType, int engineCapacity)
        {
            EngineCapacity = engineCapacity;
            LicenseType = licenseType;
        }

        public eMotorcycleLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                m_EngineCapacity = value;
            }
        }

    }
}