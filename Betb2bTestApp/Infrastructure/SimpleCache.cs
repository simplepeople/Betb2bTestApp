using System.Collections.Concurrent;

namespace Betb2bTestApp.Infrastructure
{
    public class SimpleCache<TKey, TValue> : ISimpleCache<TKey, TValue>
    {
        private readonly ConcurrentDictionary<TKey, TValue> _cache = new();
        public TValue AddOrUpdate(TKey key, TValue value)
        {
            _cache.AddOrUpdate(key, value, (_, _) => value);
            return value;
        }

        public bool TryGet(TKey key, out TValue value)
        {
            return _cache.TryGetValue(key, out value);
        }
    }
}
