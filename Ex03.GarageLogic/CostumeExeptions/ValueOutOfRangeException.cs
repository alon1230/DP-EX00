using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        public float m_MaxValue { get; }
        public float m_MinValue { get; }
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        : base()
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string message)
        : base(message)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string message, Exception inner)
        : base(message, inner)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
