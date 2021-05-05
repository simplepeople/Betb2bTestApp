namespace Betb2bTestApp.Infrastructure
{
    public interface ISimpleCache<TKey, TValue>
    {
        TValue AddOrUpdate(TKey key, TValue value);
        bool TryGet(TKey key, out TValue value);
    }
}