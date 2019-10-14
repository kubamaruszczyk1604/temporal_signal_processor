using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FastQueue
{
    class SignalProcessor
    {
        private ShiftQueue<float> m_SignalValuesQueue;
        private float[] m_Kernel;

        public SignalProcessor(float[] kernel)
        {
            m_Kernel = kernel;
            m_SignalValuesQueue = new ShiftQueue<float>(m_Kernel.Length);
        }

        public void Put(float y)
        {
            m_SignalValuesQueue.Push(y);
        }

        public float GetFilteredOutput()
        {
            float sum = 0;
            for(int i = 0; i < m_Kernel.Length; ++i)
            {
                sum += (m_Kernel[i] * m_SignalValuesQueue.Get(i));
            }
            return sum;
        }

        //object sync = new object();
        //public float GetFilteredOutput_Parallel()
        //{
        //    float sum = 0;
            
        //    Parallel.For(0, m_Kernel.Length,
        //           i => {
        //               float mul = m_Kernel[i] * m_SignalValuesQueue.Get(i);
        //               lock (sync)
        //               {
        //                   sum += mul;
        //               }

        //           });
        //    return sum;
        //}

        public void PrintSignal()
        {
            Console.Write("Signal: ");
            m_SignalValuesQueue.Print();        
        }

    }
}
