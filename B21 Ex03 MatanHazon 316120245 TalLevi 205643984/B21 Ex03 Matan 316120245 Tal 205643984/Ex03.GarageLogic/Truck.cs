namespace Ex03.GarageLogic
{
    public class Truck
    {
        private bool m_IfDrivingHazardousMaterials;
        private float m_MaximumCarryingWeight;

        public bool IfDrivingHazardousMaterials
        {
            get
            {
                return m_IfDrivingHazardousMaterials;
            }

            set
            {
                m_IfDrivingHazardousMaterials = value;
            }
        }

        public float MaximumCarryingWeight
        {
            get
            {
                return m_MaximumCarryingWeight;
            }

            set
            {
                m_MaximumCarryingWeight = value;
            }
        }

        public Truck(float i_MaximumCarryingWeight, bool i_IsCarryngDangerousMaterials)
        {
            MaximumCarryingWeight = i_MaximumCarryingWeight;
            IfDrivingHazardousMaterials = i_IsCarryngDangerousMaterials;
        }
    }
}
