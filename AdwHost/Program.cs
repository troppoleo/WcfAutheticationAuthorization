using AdwWcfServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdwHost
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                ServiceHost srvHost = new ServiceHost(typeof(ServiceAddress));
                srvHost.Open();
                Console.WriteLine("Press any key to stop the service.");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Servizio interrotto: " + ex.Message);
                Console.ReadLine();
            }
            // start the service:



            //while (true)
            //{
            //    Console.WriteLine("Press 1 to try ECHO");
            //    Console.WriteLine("Press 2 to read first AddressLine1");
            //    //Console.WriteLine("Press 3 to read first Name");
            //    //Console.WriteLine("Press 4 to read first Customer");
            //    //Console.WriteLine("Press 5 to read first 10 Customers");
            //    //Console.WriteLine("Press 6 to read first Product");
            //    //Console.WriteLine("Press 7 to read People");
            //    //Console.WriteLine("Press 8 to add person (return bool)");
            //    //Console.WriteLine("Press 9 to add person2 (return int)");
            //    Console.WriteLine("Press 0 to Exit");

            //    string myF = Console.ReadLine();

            //    switch (myF)
            //    {
            //        case "0":
            //            return;
            //            break;
            //        case "1":
            //            EchoMsg();
            //            break;
            //        case "2":
            //            ReadFirstAddressLine1();
            //            break;
            //        //case "3":
            //        //    ReadFirstName();
            //        //    break;
            //        //case "4":
            //        //    ReadFirstCustomer();
            //        //    break;
            //        //case "5":
            //        //    ReadFirstTenCustomer();
            //        //    break;
            //        //case "6":
            //        //    ReadFirstProduct();
            //        //    break;
            //        //case "7":
            //        //    ReadPeople();
            //        //    break;
            //        //case "8":
            //        //    AddPerson();
            //        //    break;
            //        //case "9":
            //        //    AddPerson2();
            //        //    break;
            //    }
            //}
        }

        //private static void ReadFirstAddressLine1()
        //{
        //    AdwWcfServiceLibrary.AdventureWorksEntities en = new AdwWcfServiceLibrary.AdventureWorksEntities();
        //    en.
        //}

        //private static void EchoMsg()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
