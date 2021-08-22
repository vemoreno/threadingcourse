using System;
using System.Threading;

namespace Threading_04_Stop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Interrupción de threads";

            string[] someCountries = new string[] { "México", "Venezuela", "Bolivia", "Rusia",
                                                               "Canada", "Peru", "Colombia" };

            Thread ourThread = new Thread(new ParameterizedThreadStart(CountCharacters));
            ourThread.Start(someCountries);

            Thread.Sleep(10000);
            ourThread.Abort(); 

            Console.WriteLine("El thread fue interrumpido");
            Console.Read();
        }

        public static void CountCharacters(object parameter)
        {
            string[] someCountries = (string[])parameter;
            Random randomValue = new Random();

            while (true)
            {
                foreach (var country in someCountries)
                {
                    Console.WriteLine("El pais de {0} tiene {1} letras.", country, country.Length);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
