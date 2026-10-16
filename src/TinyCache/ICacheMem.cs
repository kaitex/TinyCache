using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace TinyCache
{
   public interface ICacheMem<TKey,TValue> where TKey : notnull
    {
        void Set(TKey key,TValue value);
        bool  TryGet(TKey key, out TValue value);
        bool TryAdd(TKey key,  TValue value);
        string GetOrAdd(TKey key, TValue value);
        string? GetOrDefault(TKey key );
        bool ContainsKey(TKey key);
        void Clear();
        bool TryUpdate(TKey key, TValue value, TValue oldvalue );

        bool Remove(TKey key);
        KeyValuePair<int, string>[] GetAll();
    }
}