using System;
using System.Threading;

namespace Threading_09_ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Control de excepciones con threads.";

                Thread ourThread = new Thread(ThrowExceptionWithoutHandling);
                ourThread.Start();

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al ejecutar el thread: {0}", ex.Message);
            }
        }

        private static void ThrowExceptionWithoutHandling()
        {
            throw new NotImplementedException();
        }

        private static void ThrowExceptionWithHandling()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al ejecutar el thread: {0}", ex.Message);
            }
        }
    }
}
