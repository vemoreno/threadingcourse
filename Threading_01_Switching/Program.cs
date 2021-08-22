using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_01_Switching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Alternando entre main y worker threads";

            Thread ourThread = new Thread(SwitchingBetweenMainAndWorkerThreads);
            ourThread.Start();

            for (int i = 0; i < 2500; i++)
                Console.WriteLine("Valor de main thread : {0}", i);

            Console.ReadLine();
        }

        public static void SwitchingBetweenMainAndWorkerThreads()
        {
            for (int i = 0; i < 2500; i++)
                Console.WriteLine("Valor de worker thread: {0}", i);
        }
    }
}
