
using System.Collections.Concurrent;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace TinyCache
{
    public class CacheMem : ICacheMem<int, string>
    {
        private readonly ConcurrentDictionary<int, string> _cache= new ConcurrentDictionary<int,string>();

        public void Clear()
        {
            _cache.Clear();
            
        }

        public bool ContainsKey(int key)
        {
            
            return _cache.ContainsKey(key);
        }

        public KeyValuePair<int, string>[] GetAll()
        {
           return _cache.ToArray();
        }

        public string  GetOrAdd(int key, string value)
        {
        return _cache.GetOrAdd(key,value);

        }

    

        public string? GetOrDefault(int key)
        {
            
            if(_cache.TryGetValue(key,out var value))
            {
                return value;
            }
            return null;
        }

        public bool Remove(int key)
        {
            return _cache.TryRemove(key, out var value);
        }

        public void Set(int key, string value)
        {
            _cache[key] = value;
        }

        public bool TryAdd(int key, string value)
        {
    // Exception if data is already locate there thorow user exp
            return _cache.TryAdd(key, value);
            
        }

        public bool TryGet(int key, out  string value)
        {
            if(_cache.TryGetValue(key, out var storevalue) && storevalue is string typedValue)
            {
                value = typedValue;
                return  true;
            }
            
            value = default;
            return false;
        }

      

        public bool TryUpdate(int key, string value,string oldvalue)
        {
           return _cache.TryUpdate(key,value,oldvalue);
        }
    }
}