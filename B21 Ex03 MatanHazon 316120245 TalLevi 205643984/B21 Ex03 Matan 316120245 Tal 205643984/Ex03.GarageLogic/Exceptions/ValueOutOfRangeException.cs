using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        ValueOutOfRangeException(float i_MinValue, float i_MaxValue, Exception i_Inner)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
