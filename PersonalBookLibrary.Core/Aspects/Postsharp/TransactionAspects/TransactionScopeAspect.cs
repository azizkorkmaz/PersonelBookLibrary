using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PersonalBookLibrary.Core.Aspects.Postsharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect:OnMethodBoundaryAspect
    {
        private TransactionScopeOption _option;
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            /*Parametreli ctor*/
            _option = option;
        }

        public TransactionScopeAspect()
        {
            /*Parametresiz ctor*/
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            /*Burada metoda girildiğinde metodunda yapması gerekeni yazıyoruz.*/
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            /*Burada metod başarılı olduğunda complete et diyoruz.*/
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            /*Burada metod başarılı olmazsa dizpose et diyoruz.*/
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
