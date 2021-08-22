using System;
using System.Threading;

namespace Threading_06_ThreadJoins
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Esperando a los threads";
            Console.WriteLine("Procesando envío de productos...\n");

            Thread[] ourThreads = new Thread[3];

            for (int i = 0; i < 3; i++)
            {
                ourThreads[i] = new Thread(new ParameterizedThreadStart(ReceiveRequest));
                ourThreads[i].Start(Guid.NewGuid().ToString());
                ourThreads[i].Join();
            }

            Console.WriteLine("Todos los productos fueron enviados correctamente!");
            Console.ReadLine();
        }
        private static void ReceiveRequest(object parameter)
        {
            string serialNumber = (string)parameter;
            Thread.Sleep(2000);

            Console.WriteLine("Producto {0} | Recibida solicitud.", parameter);
            ProduceProduct(serialNumber);
        }
        private static void ProduceProduct(string serialNumber)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Producto {0} | Producto fabricado." , serialNumber);
            PackageProduct(serialNumber);
        }
        private static void PackageProduct(string serialNumber)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Producto {0} | Producto empaquetado.", serialNumber);
            SendPackage(serialNumber);
        }
        private static void SendPackage(string serialNumber)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Producto {0} | Producto enviado correctamente. \n", serialNumber);
        }
    }
}
