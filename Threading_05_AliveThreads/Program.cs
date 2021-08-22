using System;
using System.Linq;
using System.Threading;

namespace Threading_05_AliveThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Threads activos";

            Thread tOne = new Thread(new ParameterizedThreadStart(CountingSeries));
            tOne.Name = "Negro";
            tOne.Start(new object[] { tOne.Name, 1000, 600 });

            Thread tTwo = new Thread(new ParameterizedThreadStart(CountingSeries));
            tTwo.Name = "Morado";
            tTwo.Start(new object[] { tTwo.Name, 2000, 1200 });

            Thread tThree = new Thread(new ParameterizedThreadStart(CountingSeries));
            tThree.Name = "Verde";
            tThree.Start(new object[] { tThree.Name, 3000, 1800 });

            Thread tFour = new Thread(new ParameterizedThreadStart(CountingSeries));
            tFour.Name = "Rojo";
            tFour.Start(new object[] { tFour.Name, 4000, 2400 });

            Thread[] ourThreads = new Thread[4] { tOne, tTwo, tThree, tFour };

            while (true)
            {
                foreach (var workerThread in ourThreads)
                {
                    if (workerThread.IsAlive)
                        Console.WriteLine("Worker thread {0} está activo y corriendo.", workerThread.Name);
                       
                    else
                        Console.WriteLine("Worker thread {0} terminó correctamente.", workerThread.Name);
                }

                Thread.Sleep(2000);

                if (ourThreads.Where(t=> t.IsAlive == false).Count() == 4)
                    break;
            }

            Console.WriteLine("* * * Todos los threads terminaron correctamente.");
            Console.ReadLine();
        }

        private static void CountingSeries(object parameter)
        {
            var tParams = (object[])parameter;
    
            string name = (string)tParams[0];
            int begin = (int)tParams[1];
            int time = (int)tParams[2];

            for (int i = 0; i < 10 ; i++, begin++)
            {
                Console.WriteLine("Worker thread {0} en: {1}", name,  begin);
                Thread.Sleep(time);
            }
        }
    }
}
