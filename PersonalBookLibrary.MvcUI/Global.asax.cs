using PersonalBookLibrary.Business.DependencyResolvers.Ninject;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Security.Web;
using PersonalBookLibrary.Core.Utilities.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace PersonalBookLibrary.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            /*programa Kendi yazdığımız controllerFactoryi kullanmasını söylüyoruz.*/
            //ControllerBuilder.Current.SetControllerFactory(
            //    new NinjectControllerFactory(
            //        new BusinessModule(), new AutoMapperModule()));

            /*Servis üzerinden programı çağırdığımız için 
             * businessModule değilde ServiceModule çağır diyoruz burada. 
             * Eğerki busines üzerinden çağırırsak programı businessModule vermek zorundayız.*/
            ControllerBuilder.Current.SetControllerFactory(
                new NinjectControllerFactory(
                    new BusinessModule(), new AutoMapperModule()));
        }

        /*Authenticantion için yaptığımız çalışmalar. 
         * Burada postAuthenticantion metodunu yakalamak için yazıyoruz. 
         * Kişi bilgilerini cookie den okuyabilmek için. */
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        //program her çalıştığında burdan başlar yetki kontrolu için.
        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var autCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (autCookie == null)
                {
                    return;
                }

                var encTicket = autCookie.Value;
                if (string.IsNullOrEmpty(encTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);

                var securtiyUtilities = new SecurityUtilities();
                var identity = securtiyUtilities.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = principal;//web için user i principal olarak oluşturuyoruz. Mvc authorization içide kullanılabilir.
                Thread.CurrentPrincipal = principal;//backend için principal oluşturuldu.
            }
            catch (Exception)
            {

            }
            
        }        
    }
}
