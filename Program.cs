#define FILTER_GAUSS
//#define FILTER_BOX

using System;
using System.Diagnostics;
using System.Threading;


namespace FastQueue
{
    class Program
    {
        static void Main(string[] args)
        {
             void PrintDraw(float n)
            {
                 int no = (int)(n * 10.0f);
                 Console.WriteLine(new string('|', no));
            }


            float[] kern = KernelNormalizer.NormalizeKernel(new float[]
            {

#if FILTER_GAUSS
                0.079659f, 0.078087f, 0.073554f, 0.066577f, 0.057906f, 0.048396f,
                0.038867f, 0.029995f, 0.022243f, 0.01585f, 0.010853f, 0.007141f,
                0.004515f, 0.002743f, 0.001601f, 0.000898f, 0.000484f,0.000251f,
                0.000125f, 0.00006f, 0.000027f
#elif FILTER_BOX
                 0.04761904f, 0.04761904f, 0.04761904f, 0.04761904f, 0.04761904f, 0.04761904f,
                 0.04761904f, 0.04761904f, 0.04761904f, 0.04761904f, 0.04761904f, 0.04761904f,
                 0.04761904f, 0.04761904f, 0.04761904f, 0.04761904f, 0.04761904f, 0.04761904f,
                 0.04761904f, 0.04761904f, 0.04761904f
#else
                 1.0f
#endif



            });

            Console.ForegroundColor = ConsoleColor.Green;
            SignalProcessor processor = new SignalProcessor(kern);

            float sigPoint = 0;
            while (true)
            {
                
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                   
                    try
                    {
                        sigPoint = float.Parse(key.KeyChar.ToString());
                    }
                    catch  
                    {
                        if (key.Key == ConsoleKey.UpArrow) sigPoint += 0.1f;
                        else if (key.Key == ConsoleKey.DownArrow)
                        {
                            sigPoint -= 0.1f;
                            if (sigPoint <= 0.0f) sigPoint = 0.1f;
                        }
                        else if (key.Key == ConsoleKey.Escape) return;
                    }
                }
#if FILTER_GAUSS || FILTER_BOX
                processor.Put(sigPoint);
                PrintDraw(processor.GetFilteredOutput());
#else
                 PrintDraw(sigPoint);
#endif
                Thread.Sleep(30);
                
            }
        }
    }
}
