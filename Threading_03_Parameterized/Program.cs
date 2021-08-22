using System;
using System.Threading;

namespace Threading_03_Parameterized
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Threads parametrizados";

            Console.WriteLine("* * * Main thread empieza en: {0}" + Environment.NewLine, 
                                                        string.Format("{0:HH:mm:ss tt}", DateTime.Now));

            Thread ourThread = new Thread(new ParameterizedThreadStart(MethodForParameterizedThread));
            ourThread.Start(DateTime.Now.AddMinutes(150));

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine("Valor en main thread: {0}", 
                    string.Format("{0:HH:mm:ss tt}", DateTime.Now));
            }

            Console.ReadLine();
        }

        public static void MethodForParameterizedThread(object parameter)
        {
            DateTime threadTimeStamp = Convert.ToDateTime(parameter);
            Console.WriteLine("* * * Worker thread empieza en: {0}" + Environment.NewLine, 
                                                        string.Format("{0:HH:mm:ss tt}", threadTimeStamp));

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Valor en worker thread: {0}", 
                                                        string.Format("{0:HH:mm:ss tt}", threadTimeStamp));
            }
        }
    }
}
