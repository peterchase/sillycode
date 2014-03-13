namespace SillyCode
{
    public interface IDataSource<TKey, TValue>
    {
        TValue FetchValue(TKey key);
    }
}
