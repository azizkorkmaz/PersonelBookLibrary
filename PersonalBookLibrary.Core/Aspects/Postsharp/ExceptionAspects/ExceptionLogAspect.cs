using PersonalBookLibrary.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PersonalBookLibrary.Core.Aspects.Postsharp.ExceptionAspects
{
    [Serializable]
    public class ExceptionLogAspect : OnExceptionAspect
    {
        private LoggerService _loggerService;
        private readonly Type _loggerTeyp;

        public ExceptionLogAspect(Type loggerTeyp = null)
        {
            _loggerTeyp = loggerTeyp;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerTeyp != null)
            {
                if (_loggerTeyp.BaseType != typeof(LoggerService))
                {
                    throw new Exception("Wrong logger type");
                }

                _loggerService = (LoggerService)Activator.CreateInstance(_loggerTeyp);
            }

            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            if (_loggerService != null)
            {
                _loggerService.Error(args.Exception);
            }
        }
    }
}
