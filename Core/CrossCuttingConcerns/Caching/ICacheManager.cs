using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager 
    {
        // bir key verilir ona karşılık gelen data gelir;
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);

        // Örnek pattern Başı sonu önemli değil içinde get olanları kaldır gibi;
        void RemoveByPattern(string pattern);
    }
}
