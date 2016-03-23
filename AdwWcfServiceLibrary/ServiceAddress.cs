using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace AdwWcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServiceAddress : IServiceAddress
    {
        [OperationBehavior(Impersonation = ImpersonationOption.NotAllowed)]
        public string GetData(int value)













        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetFirstAddressLine1()
        {
            string myAddressLine1;
            using( AdventureWorksEntities awe = new AdventureWorksEntities())
            {
                myAddressLine1= awe.Address.First().AddressLine1;
            }
            return myAddressLine1;
        }


        public string GetInfoAutentication()
        {
            try
            {
                string userName = Thread.CurrentPrincipal.Identity.Name;
                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.WriteLine("UserName is Empty");
                    return "UserName is Empty";
                }

                Console.WriteLine(userName);

                bool isAuth = ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated;
                string myAuthType = ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType;
                string myName = ServiceSecurityContext.Current.PrimaryIdentity.Name;

                return string.Format("Is Authenticated: {0}, authentication type {1}, name {2}", isAuth, myAuthType, myName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "Errore";
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "GR_TEST_WCF_STAFF")]
        public string GetForStaff()
        {
            return "you staff member, are authorized";
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "GR_TEST_WCF_CONTROLLERS")]
        public string GetForController()
        {
            return "you Controller member, are authorized!!";
        }



        public string GetMsgSwitchBetweenGroup()
        {
            WindowsPrincipal wp = new WindowsPrincipal((WindowsIdentity)Thread.CurrentPrincipal.Identity);

            if (wp.IsInRole("GR_TEST_WCF_CONTROLLERS"))
            {
                return "Sei un controller";
            }

            if (wp.IsInRole("GR_TEST_WCF_STAFF"))
            {
                return "You're of the staff";
            }

            //throw new SecurityException("non sei autorizzato");
            
            return "gruppo non identificato";
        }



        public string CkSenzaImpersonation()
        {
            Console.WriteLine("\t\tThread Identity            :{0}",
                 WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("\t\tThread Identity level  :{0}",
                 WindowsIdentity.GetCurrent().ImpersonationLevel);
            Console.WriteLine("\t\thToken                     :{0}",
                 WindowsIdentity.GetCurrent().Token.ToString());

            return WindowsIdentity.GetCurrent().Name;
        }

        /// <summary>
        /// Impone l'impersonation
        /// </summary>
        /// <returns></returns>
        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public string CkImpersonationOptionRequired()
        {
            Console.WriteLine("\t\tThread Identity            :{0}",
                 WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("\t\tThread Identity level  :{0}",
                 WindowsIdentity.GetCurrent().ImpersonationLevel);
            Console.WriteLine("\t\thToken                     :{0}",
                 WindowsIdentity.GetCurrent().Token.ToString());

            return WindowsIdentity.GetCurrent().Name;
        }

        /// <summary>
        /// è il valore di default, fa l'impersonation se il client lo permette (da provare con binding diversi)
        /// </summary>
        /// <returns></returns>
        [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        public string CkImpersonationOptionAllowed()
        {
            Console.WriteLine("\t\tThread Identity            :{0}",
                 WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("\t\tThread Identity level  :{0}",
                 WindowsIdentity.GetCurrent().ImpersonationLevel);
            Console.WriteLine("\t\thToken                     :{0}",
                 WindowsIdentity.GetCurrent().Token.ToString());

            return WindowsIdentity.GetCurrent().Name;
        }

        /// <summary>
        /// questo disabilita l'impersonation
        /// </summary>
        /// <returns></returns>
        [OperationBehavior(Impersonation = ImpersonationOption.NotAllowed)]
        public string CkImpersonationOptionNotAllowed()
        {
            Console.WriteLine("\t\tThread Identity            :{0}",
                 WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("\t\tThread Identity level  :{0}",
                 WindowsIdentity.GetCurrent().ImpersonationLevel);
            Console.WriteLine("\t\thToken                     :{0}",
                 WindowsIdentity.GetCurrent().Token.ToString());

            return WindowsIdentity.GetCurrent().Name;
        }
    }
}
