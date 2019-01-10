using PersonalBookLibrary.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Logging;

namespace PersonalBookLibrary.Core.Aspects.Postsharp.LogAspects
{
    [Serializable]
    /*bu şu anlama geliyor nesne instınlarının örneklerine ve metodlarına uygula, 
     * hiçbir şekilde constructorlara uygulama diyoruz.*/
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes 
        =MulticastAttributes.Instance)]
    public class LogAspect:OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;
        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong logger type!");
            }

            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }

            try
            {
                /*t tipimiz, i ise itereter yani argumentlerimizi temsil eder.*/
                var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,//değişken ismi
                    Type = t.ParameterType.Name,//değişken tipi(string, int vb.)
                    Value = args.Arguments.GetArgument(i)//değişken değeri
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,//metodun sınıfı
                    MethodName = args.Method.Name,//metodun adı
                    Prameters = logParameters//metodun parametreleri
                };

                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {

            }
           
        }
    }
}
