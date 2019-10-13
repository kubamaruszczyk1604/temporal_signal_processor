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


            //ShiftQueue<int> fastQ = new ShiftQueue<int>(9);
            SignalProcessor processor = new SignalProcessor(new float[] { 0.8f, 0.1f, 0.1f,0.2f, 0.1f,3.4f, 0.8f, 0.1f, 0.1f, 0.2f, 0.1f, 3.4f });

            while (true)
            {
                string s = Console.ReadLine();
                Console.Clear();
                processor.Put(float.Parse(s));
                processor.PrintSignal();
                Stopwatch sw = Stopwatch.StartNew();
                for(int i = 0; i< 10000; ++i)
                {
                    processor.GetFilteredOutput();

                }
                sw.Stop();
                Console.WriteLine((sw.Elapsed.TotalSeconds/10000.0).ToString("N10"));


                //Console.WriteLine("Linear: " + processor.GetFilteredOutput().ToString());
                // Console.WriteLine("Parallel: " + processor.GetFilteredOutput_Parallel().ToString());
                //int n = GetNum(s);
                //fastQ.Push(n);
                //fastQ.Print();
                //Console.WriteLine("First is: " + fastQ.Get(0).ToString());
                //Console.WriteLine("Last is: " + fastQ.GetLast().ToString());
            }
        }
    }
}
