using System;
using System.Diagnostics; 
namespace FastQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            
            static int GetNum(string s)
            {
                int output = 0;
                while(true)
                {
                    try
                    {
                        output = int.Parse(s);
                        break;
                    }
                    catch 
                    {
                        Console.WriteLine("Entry not valid!");
                        s = Console.ReadLine();
                    }

                }
                return output;
            }


            float[] kern = KernelNormalizer.NormalizeKernel(new float[] { 0.382928f, 0.241732f, 0.060598f, 0.005977f, 0.000229f });
            float sum = 0;
            for (int i = 0; i < kern.Length; ++i)
            {
                sum += kern[i];
            }
            SignalProcessor processor = new SignalProcessor(kern);

            while (true)
            {
                string s = Console.ReadLine();
                Console.Clear();
                processor.Put(float.Parse(s));
                processor.PrintSignal();
    

                //Stopwatch sw = Stopwatch.StartNew();
                //for(int i = 0; i< 10000; ++i)
                //{
                //    processor.GetFilteredOutput();

                //}
                //sw.Stop();
                //Console.WriteLine((sw.Elapsed.TotalSeconds/10000.0).ToString("N10"));


                Console.WriteLine("Linear: " + processor.GetFilteredOutput().ToString());
               
                //int n = GetNum(s);
                //fastQ.Push(n);
                //fastQ.Print();
                //Console.WriteLine("First is: " + fastQ.Get(0).ToString());
                //Console.WriteLine("Last is: " + fastQ.GetLast().ToString());
            }
        }
    }
}
