using System;
using System.Diagnostics;
using System.Threading;
namespace FastQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            static  void PrintDraw(float n)
            {
                 int no = (int)(n * 10.0f);
                 Console.WriteLine(new string('#', no));
            }


            float[] kern = KernelNormalizer.NormalizeKernel(new float[] 
            { 
              //  0.132429f, 0.125337f, 0.106259f, 0.080693f, 0.054891f, 0.033446f,
              //0.018255f, 0.008925f, 0.003908f, 0.001533f, 0.000539f

                0.079659f, 0.078087f, 0.073554f, 0.066577f, 0.057906f, 0.048396f,
                0.038867f, 0.029995f, 0.022243f, 0.01585f, 0.010853f, 0.007141f,
                0.004515f, 0.002743f, 0.001601f, 0.000898f, 0.000484f,0.000251f,
                0.000125f, 0.00006f, 0.000027f


            });
           
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
                processor.Put(sigPoint);
                PrintDraw(processor.GetFilteredOutput());
                //PrintDraw(sigPoint);
                Thread.Sleep(30);
                
            }
        }
    }
}
