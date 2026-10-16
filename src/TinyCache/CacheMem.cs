
using System.Collections.Concurrent;

namespace TinyCache
{
    public class CacheMem : ICacheMem<int, string>
    {
        private readonly ConcurrentDictionary<int, string> _cache= new ConcurrentDictionary<int,string>();
        public bool Remove(int key)
        {
            return _cache.TryRemove(key, out var value);
        }

        public void Set(int key, string value)
        {
            _cache.TryAdd(1,value);
        }

        public bool TryGet(int key, out string value)
        {
            if(_cache.TryGetValue(key, out var storevalue) && storevalue is string typedValue)
            {
                value = typedValue;
                return  true;
            }
            
            value = default;
            return false;
        }
    }
}