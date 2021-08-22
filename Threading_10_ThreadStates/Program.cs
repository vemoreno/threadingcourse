using System;
using System.Threading;

namespace Threading_10_ThreadStates
{
    class Program
    {
        private static bool threadLoop = true;
        private static bool mainThreadLoop = true;
        private static Thread ourThread= null;
        private static int fDelay= 1;

        static void Main(string[] args)
        {
            Console.Title ="Estados de los threads";

            ourThread = new Thread(InfiniteMethod);

            while (mainThreadLoop)
            {
                Console.WriteLine("Estado del thread: {0}\n", ourThread.ThreadState.ToString());

                switch (ourThread.ThreadState)
                {
                    case ThreadState.Running:

                        fDelay = 2;
                        threadLoop = false;

                        break;
                 
                    case ThreadState.Unstarted:

                        ourThread.Start();

                        break;

                    case ThreadState.Stopped:

                        mainThreadLoop = false;

                        break;

                    case ThreadState.WaitSleepJoin:

                        ourThread.Abort();
                        fDelay = 1;

                        break;

                    case ThreadState.Aborted:

                        fDelay = 0;

                        ourThread = new Thread(InfiniteMethod);
                        ourThread.Start();

                        break;
                }

                Thread.Sleep(3000);
            }

            Console.WriteLine("\nRecorridos los estados de un thread");
            Console.ReadLine();
        }

        private static void InfiniteMethod()
        {
            while (Program.threadLoop)
            {

            }

            Thread.Sleep(3000 * fDelay);
        }
    }
}
