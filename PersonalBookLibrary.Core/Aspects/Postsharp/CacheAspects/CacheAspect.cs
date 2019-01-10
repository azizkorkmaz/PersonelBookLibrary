using PersonalBookLibrary.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PersonalBookLibrary.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;

        public CacheAspect(Type cacheType, int cacheByMinute=60)
        {
            _cacheType = cacheType;
            _cacheByMinute = cacheByMinute;
        }

        /*Hangi cachemanager gönderdi ise onu initialize etmemiz lazım.*/
        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)
            {
                throw new Exception("Wrong cache manager!");
            }

            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);

            base.RuntimeInitialize(method);
        }

        /*Bu method calıştığında daha metodun içine girmeden ne yapılmasını istiyoruz.*/
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,//metodun namespace i için
                args.Method.ReflectedType.Name,//metodun class name i için
                args.Method.Name);//metodun name i için
            var arguments = args.Arguments.ToList();//metodun parametlerine ulaşmak için
            var key = string.Format("{0}({1})", methodName,
                string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));

            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            base.OnInvoke(args);

            _cacheManager.Add(key, args.ReturnValue, _cacheByMinute);
        }
    }
}
