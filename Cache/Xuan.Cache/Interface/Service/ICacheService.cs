using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xuan.Cache
{
    /// <summary>
    /// ICacheService
    /// </summary>
    public interface ICacheService<TKey, TValue>
    {
        /// <summary>
        /// 缓存预加载
        /// </summary>
        Task PreloadCache();

        /// <summary>
        /// 刷新缓存
        /// </summary>
        Task<bool> RefreshCacheAsync(TKey key);

        /// <summary>
        /// 刷新缓存
        /// </summary>
        Task<bool> RefreshCacheAsync(TKey key, TValue value);

        /// <summary>
        /// 批量删除缓存
        /// </summary>
        Task<bool> RefreshCacheManyAsync(KeyValuePair<TKey, TValue>[] values);

        /// <summary>
        /// 批量删除缓存
        /// </summary>
        Task<bool> RefreshCacheManyAsync(TKey[] keys);

        /// <summary>
        /// 获取
        /// </summary>
        Task<TValue> GetByKeyAsync(TKey key);

        /// <summary>
        /// 批量获取
        /// </summary>
        Task<IEnumerable<TValue>> GetByKeysAsync(TKey[] keys);

    }
}
