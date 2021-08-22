using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_02_Naming
{
    class Program
    {
        private Thread ourThread { get; set; }

        static void Main(string[] args)
        {
            Console.Title = "Estableciendo nombre a threads";

            Thread.CurrentThread.Name = "Main";

            Program app = new Program();
            app.RunThreads();
        }

        private void RunThreads()
        {
            ourThread = new Thread(WorkerThread);
            ourThread.Name = "Worker";
            ourThread.Start();

            for (int i = 0; i < 2500; i++)
                Console.WriteLine("{0} Este thread es:  {1}", i, Thread.CurrentThread.Name);

            Console.ReadLine();
        }

        public void WorkerThread()
        {
            for (int i = 0; i < 2500; i++)
                Console.WriteLine("{0} Este thread es:  {1}", i, ourThread.Name);
        }
    }
}
