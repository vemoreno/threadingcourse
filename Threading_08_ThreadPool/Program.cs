using System;
using System.Diagnostics;
using System.Threading;

namespace Threading_08_ThreadPool
{
    class Program
    {
        private static Stopwatch timer = new Stopwatch();

        static void Main(string[] args)
        {
            Console.Title = "Subprocesos con Threading Pool";
            
            string[] words = new string[] { "Escudo", "Castillo", "Lanza", "Catapulta",
                                            "Espada", "Cañón", "Flecha", "Armadura"};

            ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);

            timer.Start();
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoReverse), words);

            Thread.Sleep(1000);
            timer.Start();

            Thread ourThread = new Thread(new ParameterizedThreadStart(DoReverse));
            ourThread.Start(words);
         
            Console.ReadLine();
        }

        private static void DoReverse(object parameter)
        {
            string[] words = parameter as string[];
          
            foreach (var foundWord in words)
            {
                char[] anyWord = foundWord.ToCharArray();
                Array.Reverse(anyWord);

                Console.WriteLine("Palabra {0} de forma invertida es {1}: ", foundWord, new string(anyWord));
            }

            if (Thread.CurrentThread.IsThreadPoolThread)
                Console.WriteLine("\n* * * Tiempo total al tratar con Thread Pool: {0} \n", timer.Elapsed);
            
            else
                Console.WriteLine("\n* * * Tiempo total al tratar con Thread {0} \n", timer.Elapsed);

            timer.Reset();
        }
    }
}
