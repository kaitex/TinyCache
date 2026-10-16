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
        bool Remove(TKey key);
    }
}