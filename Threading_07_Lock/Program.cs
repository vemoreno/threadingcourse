using System;
using System.Collections.Generic;
using System.Threading;

namespace Threading_07_Lock
{
    class Program
    {
        private static object threadLock = new object();
        private static List<string> onlyCandies= new List<string>();  

        static void Main(string[] args)
        {
            Console.Title = "Bloqueo de recursos para threads";

            Thread ourThread = new Thread(new ParameterizedThreadStart(AddCandy));
            ourThread.Start(new string[] { "Mazapan", "Chicle", "Paleta", "Gomita", "Chocolate" });

            Thread.Sleep(500);
            AddCandy(new string[] { "Sal", "Chile", "Vinagre", "Pimienta" });

            Console.WriteLine("La lista fue llenada de la siguiente manera: \n");

            foreach (var candy in onlyCandies)
                Console.WriteLine("{0} \n", candy);

            Console.ReadLine();
        }

        public static void AddCandy(object parameter)
        {
            Console.WriteLine("Agregando a lista...\n");

            var candies = (string[])parameter;
            
            lock (threadLock)
            {
                foreach (var candy in candies)
                {
                    onlyCandies.Add(candy);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
