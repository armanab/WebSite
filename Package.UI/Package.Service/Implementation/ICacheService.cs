namespace Package.Service.Implementation
{
    public interface ICacheService
    {
        T Get<T>(string key);
        void Set<T>(string key, T value);
        void Remove(string key);
    }
}