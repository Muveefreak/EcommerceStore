using Auctria.EcommerceStore.Core.Application.Common.Contracts;
using Microsoft.Extensions.Caching.Memory;

namespace Auctria.EcommerceStore.Infrastructure.Cache
{
    public class CacheApplicationService<T> : ICacheApplicationService<T> where T : class
    {
        private readonly IMemoryCache _cache;


        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="cache"></param>
        public CacheApplicationService(IMemoryCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        /// <summary>
        ///     Delete
        /// </summary>
        /// <returns></returns>
        public void DeleteCachedItems(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        ///     Get 
        /// </summary>
        /// <returns></returns>
        public T GetCachedItems(string key)
        {
            T genericItem;

            _cache.TryGetValue<T>(key, out genericItem);

            return genericItem;
        }

        /// <summary>
        ///     Set
        /// </summary>
        /// <param name="entry"></param>
        public void SetCachedItems(T entry, string key)
        {
            // Set cache options
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));

            _cache.Set(key, entry, cacheEntryOptions);
        }

        /// <summary>
        ///     Get list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetCachedItemsList(string key)
        {
            IEnumerable<T> genericItems;

            _cache.TryGetValue<IEnumerable<T>>(key, out genericItems);

            return genericItems;
        }

        /// <summary>
        ///     Set List
        /// </summary>
        /// <param name="entry"></param>
        public void SetListCachedItems(IEnumerable<T> entry, string key)
        {
            // Set cache options
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));

            _cache.Set(key, entry, cacheEntryOptions);
        }
    }
}
