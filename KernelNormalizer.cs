using System;
using System.Collections.Generic;
using System.Text;

namespace FastQueue
{
    class KernelNormalizer
    {
        static public float [] NormalizeKernel(float [] kernel)
        {
            float sum = 0;
            for(int i=0;i<kernel.Length;++i)
            {
                sum += kernel[i];
            }
            float normCoeff = 1.0f / sum;

            float[] output = new float[kernel.Length];
            for(int i=0; i< output.Length;++i)
            {
                output[i] = kernel[i] * normCoeff;
            }
            return output;
        }
    }
}
