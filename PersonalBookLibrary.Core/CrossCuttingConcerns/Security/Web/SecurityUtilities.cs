using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace PersonalBookLibrary.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = SetId(ticket),
                //UserName = SetUserName(ticket),
                FirstName = SetFirstName(ticket),
                LastName = SetLastName(ticket),
                Email = SetEmail(ticket),
                Roles = SetRoles(ticket),
                Name = SetName(ticket),
                AuthenticationType = SetAuthenticationType(),
                IsAuthenticated = SetIsAuthenticated()
            };

            return identity;
        }

        private bool SetIsAuthenticated( )
        {
            return true;
        }

        private string SetAuthenticationType()
        {
            return "Forms";
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            string[] roles = data[1].Split(new char[] { ',' } ,
                StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3];
        }

        private string SetFirstName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }

        //private string SetUserName(FormsAuthenticationTicket ticket)
        //{
        //    throw new NotImplementedException();
        //}

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return new Guid(data[4]);
        }
    }
}
