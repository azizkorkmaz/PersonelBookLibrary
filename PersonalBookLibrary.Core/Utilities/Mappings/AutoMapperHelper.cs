using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Core.Utilities.Mappings
{
    public class AutoMapperHelper
    {
        /*Liste dönderen metotler için*/
        public static List<T> MapToSameTypeList<T>(List<T> list)
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<T, T>();
            });

            List<T> result = Mapper.Map<List<T>, List<T>>(list);
            return result;
        }

        /*object dönderen metotlar için*/
        public static T MapToSameType<T>(T dtObject)
        {
            Mapper.Initialize(c => { c.CreateMap<T, T>(); });

            T result = Mapper.Map<T, T>(dtObject);
            return result;
        }
    }
}
