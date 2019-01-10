using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Core.CrossCuttingConcerns.Security
{
    public class Identity : IIdentity
    {
        //set; özelliğini biz ekledik. çünkü buralara müdahale etmek istiyoruz.
        public string AuthenticationType{ get; set; }//form authentication tipin de
        public bool IsAuthenticated { get; set; }//authentica mi
        public string Name { get; set; }//identitynin adı

        //kendi ihtiyacımıza göre eklediğimiz propertiyler
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
