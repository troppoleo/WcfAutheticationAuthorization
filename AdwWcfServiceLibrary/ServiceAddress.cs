using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace AdwWcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServiceAddress : IServiceAddress
    {
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
    }
}
