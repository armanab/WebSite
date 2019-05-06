using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Package.Service.Implementation
{
    internal class CacheService : ICacheService
    {
        private IMemoryCache cache;

        public CacheService(IMemoryCache _cache)
        {
            cache = _cache;
        }

        public T Get<T>(string key)
        {
            object _result = null;
            //var result = cache.Get<T>(key);

            if (cache.TryGetValue(key, out _result))
            {
                return (T)_result;
            }
            else
            {
                return default(T);
            }
        }

        public void Set<T>(string key, T value)
        {
            cache.Set<T>(key, value);
        }


        public void Remove(string key)
        {
            cache.Remove(key);
        }

    }

    public static class DeepCopyExtentionMethods
    {
        /// <summary>
        /// Creates a deep copy of an object. Must be [Serializable] and sometimes have a deserialization constructor (see http://stackoverflow.com/a/5017346/2440) 
        /// </summary>
        public static T DeepCopy<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}