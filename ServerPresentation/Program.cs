using ServerLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerPresentation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Action<string> logger = message => Console.WriteLine(message);

            try
            {
                using (CommunicationManager communicationManager = new CommunicationManager(Int32.Parse(Properties.Resources.PortNumber), new OrderService(true), logger))
                {
                    await communicationManager.InitServerAsync();
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown by the application: {ex}");
            }
        }
    }
}
