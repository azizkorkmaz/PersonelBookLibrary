using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Core.Utilities.Common
{
    public class WcfProxy<T>
    {
        /*http://localhost:53396/CategoryService.svc 
         * bizim servis adresi bu şekilde olacak bunu dinamik hale getirecez. 
         * Burada ki T de ICategoryService şeklinde olacak. 
         * Bu doğrultuda address stringinizi formatlayacağız.*/

        public static T CreateChannel()
        {
            string baseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            string address = string.Format(baseAddress, typeof(T).Name.Substring(1));

            var binding = new BasicHttpBinding();
            var channel = new ChannelFactory<T>(binding, address);

            return channel.CreateChannel();
        }

    }
}
