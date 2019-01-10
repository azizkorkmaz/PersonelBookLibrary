using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        /*AutCache yöntemiyle cache yapacağız. Her cache datasına bir isim vermek zorundayız. Buna göre ihityacımız olan metodları aşağıya ekliyoruz.*/

        T Get<T>(string key);//cache datasını verdiğim key e göre getir.
        void Add(string key, object data, int cacheTime);//keye göre data ekle ve kalma süresini ver
        bool IsAdd(string key);//daha önce keye uygun cache data eklenmiş mi.
        void Remove(string key);//cache ten verdiğim keye göre datayı sil.
        void RemoveByPattern(string pattern);//bazen bir regularexprestiona göre silebilirim.
        void Clear();//tamamen cache temizlemek isteyebilirim.
    }
}
