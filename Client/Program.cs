using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //string myBinding = "netHttpBinding_IServiceAddress";
            string myBinding = "BasicHttpBinding_IServiceAddress";
            //string myBinding = "ws2007HttpBinding_IServiceAddress";

            //ServiceReference1.ServiceAddressClient sa = new ServiceReference1.ServiceAddressClient("netHttpBinding_IServiceAddress");
            //ServiceReference1.ServiceAddressClient sa = new ServiceReference1.ServiceAddressClient("BasicHttpBinding_IServiceAddress");
            //ServiceReference1.ServiceAddressClient sa = new ServiceReference1.ServiceAddressClient("ws2007HttpBinding_IServiceAddress");
            ServiceReference1.ServiceAddressClient sa = new ServiceReference1.ServiceAddressClient(myBinding);

            if (myBinding == "BasicHttpBinding_IServiceAddress")
            {
                /// con questo tipo di binding mi devo per forza autenticare se voglio far sapere al wcf chi sono
                /// altrimentì arrivere al wcf l'anonimo
                sa.ClientCredentials.UserName.UserName = "depalle1b\\Administrator";
                sa.ClientCredentials.UserName.Password = "Password01";

            }

            print(sa.Endpoint.Name);

            while (true)
            {
                print("Presso 0 to exit");
                print("Presso 1 to getdata(10)");
                print("Presso 2 get authentication Info");
                print("Press 3 get first address");
                print("Press 4 call GetForStaff");
                print("Press 5 call GetForController");
                print("Press 6 call GetMsgSwitchBetweenGroup");
                
                string myInput = Console.ReadLine();

                switch (myInput)
                {
                    case "0":
                        return;
                        break;
                    case "1":
                        Console.WriteLine(sa.GetData(10));
                        break;
                    case "2":
                        //Console.WriteLine(sa.Geta(10));
                        print(sa.GetInfoAutentication());
                        break;

                    case "3":
                        //Console.WriteLine(sa.Geta(10));
                        print(sa.GetFirstAddressLine1());
                        break;

                    case "4":
                        try
                        {
                            sa = new ServiceReference1.ServiceAddressClient(myBinding);

                            sa.ClientCredentials.Windows.ClientCredential.Domain = "depalle1b";
                            sa.ClientCredentials.UserName.UserName = "Bert";
                            sa.ClientCredentials.UserName.Password = "Pa$$w0rd";
                        
                            print(sa.GetForStaff());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }                        
                        break;

                    case "5":
                        try 
                        {
                            sa = new ServiceReference1.ServiceAddressClient(myBinding);

                            sa.ClientCredentials.Windows.ClientCredential.Domain = "depalle1b";
                            sa.ClientCredentials.UserName.UserName = "Fred";
                            sa.ClientCredentials.UserName.Password = "Pa$$w0rd";

                            print(sa.GetForController());
                        }
                        catch(Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }
                        break;

                    case "6":
                        try
                        {
                            sa = new ServiceReference1.ServiceAddressClient(myBinding);

                            sa.ClientCredentials.Windows.ClientCredential.Domain = "depalle1b";
                            sa.ClientCredentials.UserName.UserName = "Fred";
                            sa.ClientCredentials.UserName.Password = "Pa$$w0rd";

                            print(sa.GetMsgSwitchBetweenGroup());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }
                        break;

                }
            }
        }

        static void print(string m)
        {
            Console.WriteLine(m);
        }
    }
}
