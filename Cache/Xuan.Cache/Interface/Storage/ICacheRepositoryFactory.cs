using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache
{
    /// <summary>
    /// IEntityCacheFactory
    /// </summary>
    public interface ICacheRepositoryFactory
    {
        /// <summary>
        /// CreateEntityCache
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="cacheInstance"></param>
        /// <returns></returns>
        ICacheRepository<TKey, TValue> CreateEntityCache<TKey, TValue>(string cacheInstance) where TValue : class;
    }
}
