using System;
using System.Collections.Generic;
using System.Text;

namespace FastQueue
{
    class ShiftQueue<T>
    {
        private T[] m_Data;
        private int m_Ptr;  

        public ShiftQueue(int size)
        {
            if (size < 1) size = 1;
            m_Data = new T[size];
            m_Ptr = 0;
        }

        public void Push(T entry)
        {
            m_Data[m_Ptr] = entry;
            m_Ptr = (++m_Ptr) % m_Data.Length;
           
        }

        public T GetLast()
        {
            return m_Data[m_Ptr];
        }

        public T Get(int position)
        {
            position = position % m_Data.Length;
            int index = (m_Ptr + m_Data.Length - position-1) % m_Data.Length;
            return m_Data[index];

        }

        public void PrintRaw()
        {
            string assembly = "";

            for(int i = 0; i < m_Data.Length; ++i)
            {
                assembly += m_Data[i].ToString();
                if (i < m_Data.Length - 1) assembly += ",";
            }
            Console.WriteLine(assembly);
        }

        public void Print()
        {
            string assembly = "";

            for (int i = 0; i < m_Data.Length; ++i)
            {
                assembly += this.Get(i).ToString();
                if (i < m_Data.Length - 1) assembly += ",";
            }
            Console.WriteLine(assembly);
        }
      
    }
}
