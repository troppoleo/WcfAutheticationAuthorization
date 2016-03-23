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
            //string myBinding = "BasicHttpBinding_IServiceAddress";
            string myBinding = "ws2007HttpBinding_IServiceAddress";

            //ServiceReference1.ServiceAddressClient sa = new ServiceReference1.ServiceAddressClient("netHttpBinding_IServiceAddress");
            //ServiceReference1.ServiceAddressClient sa = new ServiceReference1.ServiceAddressClient("BasicHttpBinding_IServiceAddress");
            //ServiceReference1.ServiceAddressClient sa = new ServiceReference1.ServiceAddressClient("ws2007HttpBinding_IServiceAddress");
            ServiceReference1.ServiceAddressClient sa = new ServiceReference1.ServiceAddressClient(myBinding);

            if (myBinding == "BasicHttpBinding_IServiceAddress")
            {
                /// con questo tipo di binding mi devo per forza autenticare se voglio far sapere al wcf chi sono
                /// altrimentì al wcf arriva l'anonimo 
                //sa.ClientCredentials.UserName.UserName = "depalle1b\\Administrator";
                //sa.ClientCredentials.UserName.Password = "Password01";

                sa.ClientCredentials.Windows.ClientCredential.Domain = "depalle1b";
                sa.ClientCredentials.Windows.ClientCredential.UserName = "Administrator";
                sa.ClientCredentials.Windows.ClientCredential.Password = "Password01";
            }

            print("---------------Endpoint Name:------------");
            print(sa.Endpoint.Name);
            print("---------------------------");

            while (true)
            {
                print("Press -5 per usare Fred ");      
                print("Press -4 chi è l'utente corrente?? ");                
                print("Press -3 imposto l'amministratore");
                print("Press -2 per usare Bert");
                print("Press -1 per usare l'anonimo");
                print("Press 0 to exit");
                print("Press 1 to getdata(10)");
                print("Press 2 get authentication Info");
                print("Press 3 get first address");
                print("Press 4 call GetForStaff");
                print("Press 5 call GetForController");
                print("Press 6 call GetMsgSwitchBetweenGroup");
                print("Press 7 call CkSenzaImpersonation");
                print("Press 8 call CkImpersonationOptionAllowed");
                print("Press 9 call CkImpersonationOptionNotAllowed");
                print("Press 10 call CkImpersonationOptionRequired");
                print("Press 11 call CkImpersonationOptionRequired e non passo le credenziali");
                print("Press 12 call CkSenzaImpersonation e non passo le credenziali");


                string myInput = Console.ReadLine();

                switch (myInput)
                {
                    case "-5":
                        sa = new ServiceReference1.ServiceAddressClient(myBinding);
                        SetFredCredential(sa);

                        GetUtenteCorrente(sa);

                        break;

                    case "-4":
                        GetUtenteCorrente(sa);

                        break;

                    case "-3":
                        sa = new ServiceReference1.ServiceAddressClient(myBinding);

                        //sa.ClientCredentials.UserName.UserName = "depalle1b\\Administrator";
                        //sa.ClientCredentials.UserName.Password = "Password01";

                        sa.ClientCredentials.Windows.ClientCredential.Domain = "depalle1b";
                        sa.ClientCredentials.Windows.ClientCredential.UserName = "Administrator";
                        sa.ClientCredentials.Windows.ClientCredential.Password = "Password01";

                        GetUtenteCorrente(sa);

                        break;

                    case "-2":
                        sa = new ServiceReference1.ServiceAddressClient(myBinding);
                        SetBertCredential(sa);

                        GetUtenteCorrente(sa);

                        break;

                    case "-1":                        
                        sa = new ServiceReference1.ServiceAddressClient(myBinding);
                        
                        print("Anonimo impostato");
                        
                        GetUtenteCorrente(sa);

                        break;

                    case "0":
                        return;
                        break;

                    case "1":
                        try
                        {
                            PrintForOutput(sa.GetData(10));
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }  
                        break;

                    case "2":
                        //Console.WriteLine(sa.Geta(10));
                        try 
                        {
                            PrintForOutput(sa.GetInfoAutentication());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }  
                        break;

                    case "3":
                        //Console.WriteLine(sa.Geta(10));
                        print(sa.GetFirstAddressLine1());
                        break;

                    case "4":
                        try
                        {
                            //sa = new ServiceReference1.ServiceAddressClient(myBinding);
                            //SetBertCredential(sa);

                            PrintForOutput(sa.GetForStaff());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }                        
                        break;

                    case "5":
                        try 
                        {
                            //sa = new ServiceReference1.ServiceAddressClient(myBinding);
                            //SetFredCredential(sa);

                            PrintForOutput(sa.GetForController());
                        }
                        catch(Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }
                        break;

                    case "6":
                        try
                        {
                            //sa = new ServiceReference1.ServiceAddressClient(myBinding);                            
                            //SetFredCredential(sa);

                            PrintForOutput(sa.GetMsgSwitchBetweenGroup());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }
                        break;

                    case "7":
                        try
                        {
                            //sa = new ServiceReference1.ServiceAddressClient(myBinding);
                            //SetFredCredential(sa);

                            GetUtenteCorrente(sa);

                            PrintForOutput(sa.CkSenzaImpersonation());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }
                        break;

                    case "8":
                        try
                        {
                            //ImpersonationOption.Allowed
                            //sa = new ServiceReference1.ServiceAddressClient(myBinding);
                            //SetBertCredential(sa);

                            GetUtenteCorrente(sa);

                            PrintForOutput(sa.CkImpersonationOptionAllowed());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }
                        break;

                    case "9":
                        try
                        {
                            //ImpersonationOption.NotAllowed
                            //sa = new ServiceReference1.ServiceAddressClient(myBinding);
                            //SetBertCredential(sa);
                            
                            GetUtenteCorrente(sa);

                            PrintForOutput(sa.CkImpersonationOptionNotAllowed());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }
                        break;

                    case "10":
                        try
                        {
                            //ImpersonationOption.Required
                            //sa = new ServiceReference1.ServiceAddressClient(myBinding);
                            //SetBertCredential(sa);

                            GetUtenteCorrente(sa);

                            PrintForOutput(sa.CkImpersonationOptionRequired());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }
                        break;

                    case "11":
                        try
                        {
                            //ImpersonationOption.Required
                            //sa = new ServiceReference1.ServiceAddressClient(myBinding);

                            print("se non passo le credenziali");
                            print("deve dare errore");

                            PrintForOutput(sa.CkImpersonationOptionRequired());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }
                        break;

                    case "12":
                        try
                        {
                            //sa = new ServiceReference1.ServiceAddressClient(myBinding);

                            print("non passo le credenziali");

                            PrintForOutput(sa.CkSenzaImpersonation());
                        }
                        catch (Exception ex)
                        {
                            print("Error: " + ex.Message);
                        }
                        break;
                }
            }
        }

        private static void SetFredCredential(ServiceReference1.ServiceAddressClient sa)
        {
            sa.ClientCredentials.Windows.ClientCredential.Domain = "depalle1b";
            sa.ClientCredentials.Windows.ClientCredential.UserName = "Fred";
            sa.ClientCredentials.Windows.ClientCredential.Password = "Pa$$w0rd";
            
            GetUtenteCorrente(sa);
        }

        private static void SetBertCredential(ServiceReference1.ServiceAddressClient sa)
        {
            sa.ClientCredentials.Windows.ClientCredential.Domain = "depalle1b";
            sa.ClientCredentials.Windows.ClientCredential.UserName = "Bert";
            sa.ClientCredentials.Windows.ClientCredential.Password = "Pa$$w0rd";
            
            GetUtenteCorrente(sa);
        }

        private static void GetUtenteCorrente(ServiceReference1.ServiceAddressClient sa)
        {
            print(""); 
            print("------------------- Utente corrente:  --------------------");
            print("sa.ClientCredentials.Windows.ClientCredential.Domain: " + sa.ClientCredentials.Windows.ClientCredential.Domain);
            print("sa.ClientCredentials.UserName.UserName: " + sa.ClientCredentials.UserName.UserName);
            print("sa.ClientCredentials.UserName.Password: " + sa.ClientCredentials.UserName.Password);

            print("sa.ClientCredentials.Windows.ClientCredential.Domain: " + sa.ClientCredentials.Windows.ClientCredential.Domain);
            print("sa.ClientCredentials.Windows.ClientCredential.UserName: " + sa.ClientCredentials.Windows.ClientCredential.UserName);
            print("sa.ClientCredentials.Windows.ClientCredential.Password: " + sa.ClientCredentials.Windows.ClientCredential.Password);
            print("---------------------------------------");
            print("");
        }

        static void PrintForOutput(string m)
        {
            print("");
            print("------->> OUPTUT <<-------");
            Console.WriteLine(m);
            print("--------------------------");
            print("");
        }

        static void print(string m)
        {
            Console.WriteLine(m);
        }
    }
}
