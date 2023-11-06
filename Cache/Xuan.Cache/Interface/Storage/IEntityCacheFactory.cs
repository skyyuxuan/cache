using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xuan.Cache.Model.Storage;

namespace Xuan.Cache.Storage
{
    /// <summary>
    /// IEntityCacheFactory
    /// </summary>
    public interface IEntityCacheFactory
    {
        /// <summary>
        /// CreateEntityCache
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="option"></param>
        /// <returns></returns>
        IEntityCache<TKey, TValue> CreateEntityCache<TKey, TValue>(EntityCacheOption option) where TValue : class;
    }
}
