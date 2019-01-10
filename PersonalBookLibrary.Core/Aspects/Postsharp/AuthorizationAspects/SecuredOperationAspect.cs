using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Core.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    /*Metodun hemen başında çalıştığı için OnMethodBoundaryAspect en türemesi gerekli.*/
    public class SecuredOperationAspect:OnMethodBoundaryAspect
    {
        public string Roles { get; set; }


        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;

            for (int i = 0; i < roles.Length; i++)
            {
                if (Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuthorized = true;
                }
            }

            if (isAuthorized==false)
            {
                throw new SecurityException("You are not authorized!");
            }
        }

    }
}
