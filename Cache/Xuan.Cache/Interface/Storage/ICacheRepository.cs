using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xuan.Cache
{
    /// <summary>
    /// ICacheRepository
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface ICacheRepository<TKey, TValue>
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="key">建</param>
        /// <param name="value">值</param>
        Task<bool> SaveCacheAsync(TKey key, TValue value, TimeSpan? expireTime);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="values">保存集合</param> 
        bool SaveCacheMany(CacheManyOperationModel<TKey, TValue>[] values);

        /// <summary>
        /// 获得
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        Task<TValue> GetCacheAsync(TKey key);

        /// <summary>
        /// 批量获得
        /// </summary>
        /// <param name="keys">主键集合</param>
        /// <returns></returns>
        Dictionary<TKey, TValue> GetCacheMany(TKey[] keys);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key">主键</param>
        Task<bool> DeleteCacheAsync(TKey key);
    }
}
