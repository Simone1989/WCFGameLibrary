using System.ServiceModel;
using WCFGameLibrary.Services;
using System;
using System.Diagnostics;

namespace WCFGameLibrary.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (ServiceHost host = new ServiceHost(typeof(WCFGameLibraryService)))
                {
                    host.Open();
                    Console.WriteLine("Self hosting!");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    host.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
