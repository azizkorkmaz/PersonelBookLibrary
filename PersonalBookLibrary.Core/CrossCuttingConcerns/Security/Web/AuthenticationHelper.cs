using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace PersonalBookLibrary.Core.CrossCuttingConcerns.Security.Web
{
    public class AuthenticationHelper
    {
        /*Bu helperı web için yazıyoruz.*/
        public static void CreateAutCookie(Guid id, string userName, string email, DateTime
            expiration, string[] roles, bool rememberMe, string firstName, string lastName)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration,
                rememberMe, CreateAuthTags(email, roles, firstName, lastName, id));

            string encTicket = FormsAuthentication.Encrypt(authTicket);

            HttpContext.Current.Response.Cookies.Add(new HttpCookie
                (FormsAuthentication.FormsCookieName, encTicket));

        }

        /*Burada FormsAuthentication yaptığımız için bizden bir userData istiyor.
         *  bizde bu userData yı formatlı bir şekilde elde edebilmek için bu metodu yazıyoruz.*/
        private static string CreateAuthTags(string email, string[] roles, string firstName, string lastName, Guid id)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(email);
            stringBuilder.Append("|");

            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);

                if (i<roles.Length-1)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("|");
            stringBuilder.Append(firstName);
            stringBuilder.Append("|");
            stringBuilder.Append(lastName);
            stringBuilder.Append("|");
            stringBuilder.Append(id);

            return stringBuilder.ToString();

        }
    }
}
