using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xuan.Cache.Model.Storage;

namespace Xuan.Cache.Storage
{
    ///<seealso cref="IEntityCache<TKey, TValue>"/>
    public class StackExchangeRedisEntityCache<TKey, TValue> : IEntityCache<TKey, TValue> where TValue : class
    {
        private readonly IRedisProvider _cache;
        private readonly ICacheSerializer _serializer;
        private readonly RedisEntityCacheOptions _options;
        private readonly EntityCacheOptions _entityCacheOptions;

        /// <summary>
        /// RedisEntityCache
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="options"></param>
        /// <param name="entityCacheOptions"></param>
        public StackExchangeRedisEntityCache(IRedisProvider cache, IOptions<RedisEntityCacheOptions> options, EntityCacheOptions entityCacheOptions)
        {
            _cache = cache;
            _options = options.Value;
            _entityCacheOptions = entityCacheOptions;
            //_serializer
        }

        public async Task<bool> SaveCacheAsync(TKey key, TValue value, TimeSpan? expireTime)
        {
            try
            {
                var redis = GetRedis();
                byte[] val = null;
                string cacheKey = GetCacheKey(key);
                if (value != null)
                {
                    val = await _serializer.SerializeAsync(value);
                }
                return await redis.StringSetAsync(cacheKey, val, expireTime);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return false;
        }

        ///<seealso cref="IEntityCache{TKey, TValue}.SaveCacheMany(CacheManyOperationModel{TKey, TValue}[])"/>
        public bool SaveCacheMany(CacheManyOperationModel<TKey, TValue>[] values)
        {
            var redis = GetRedis();
            if (values == null || values.Count() == 0)
            {
                throw new ArgumentNullException("values");
            }
            var batch = redis.CreateBatch();
            var semaphore = new SemaphoreSlim(1);
            try
            {
                CacheServiceInternalHelper.BatchInvoke(values, _options.MaxParallelCache, async (saveValues) =>
                {
                    try
                    {
                        await semaphore.WaitAsync();
                        //List<Task> batchTask = new();
                        foreach (var saveValue in saveValues)
                        {
                            var cacheKey = (RedisKey)GetCacheKey(saveValue.Key);
                            var cacheValue = await _serializer.SerializeAsync(saveValue.Value);
                            var task = batch.StringSetAsync(cacheKey, cacheValue, saveValue.ExpireTime);
                            //batchTask.Add(task);
                        }
                        batch.Execute();
                        //await Task.WhenAll(batchTask);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                });
                return true;
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return false;
        }

        ///<seealso cref="IEntityCache{TKey, TValue}.GetCacheAsync(TKey)"/>
        public async Task<TValue> GetCacheAsync(TKey key)
        {
            try
            {
                var redis = GetRedis();
                string cacheKey = GetCacheKey(key);
                byte[] value = await redis.StringGetAsync(cacheKey);
                if (value != null)
                {
                    var val = await _serializer.DeserializeAsync<TValue>(value);
                    return val;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return null;
        }

        ///<seealso cref="IEntityCache{TKey, TValue}.GetCacheMany(TKey[])"/>
        public Dictionary<TKey, TValue> GetCacheMany(TKey[] keys)
        {
            var redis = GetRedis();
            if (keys == null)
            {
                throw new NullReferenceException("keys");
            }
            var effectiveKeys = keys.Where(_ => _ != null).Select(_ => _).ToArray();
            if (effectiveKeys?.Count() <= 0)
            {
                throw new ArgumentNullException("effectiveKeys");
            }
            RedisKey[] effectiveCacheKeys = effectiveKeys.Select(_ => (RedisKey)GetCacheKey(_)).ToArray();
            var semaphore = new SemaphoreSlim(1);
            var dataValues = new List<TValue>();
            try
            {
                CacheServiceInternalHelper.BatchInvoke<RedisKey>(effectiveCacheKeys, _options.MaxParallelCache, async (rKeys) =>
                {
                    try
                    {
                        await semaphore.WaitAsync();
                        RedisValue[] redisValues = redis.StringGet(rKeys.ToArray());
                        foreach (var redisValue in redisValues)
                        {
                            TValue value = await _serializer.DeserializeAsync<TValue>((byte[])redisValue);
                            dataValues.Add(value);
                        }
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                });
                return effectiveKeys.Zip(dataValues, (key, value) => new { key, value }).ToDictionary(_ => _.key, _ => _.value);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            Dictionary<TKey, TValue> errorResult = new Dictionary<TKey, TValue>();
            foreach (var key in effectiveKeys)
            {
                if (!errorResult.ContainsKey(key))
                {
                    errorResult[key] = null;
                }
            }
            return errorResult;
        }

        ///<seealso cref="IEntityCache{TKey, TValue}.DeleteCacheAsync(TKey)"/>
        public async Task<bool> DeleteCacheAsync(TKey key)
        {
            try
            {
                var redis = GetRedis();
                RedisKey cacheKey = (RedisKey)GetCacheKey(key);
                return await redis.KeyDeleteAsync(cacheKey);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
            return false;
        }

        /// <summary>
        /// Get IDatabase
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        protected IDatabase GetRedis()
        {
            var redis = _cache.GetDatabase() as IDatabase;
            if (redis == null)
            {
                throw new NullReferenceException("redis");
            }
            return redis;
        }

        /// <summary>
        /// 将主键转换成字符串
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>字符串</returns>
        protected virtual string GetCacheKey(TKey key)
        {
            string cacheKey = key.ToString();
            return $"{{{CacheConstants.CacheServiceName}:{_options.InstanceName}:{CacheConstants.CacheEntityName}:{_entityCacheOptions.EntityName}}}:{cacheKey}";
        }

        /// <summary>
        /// HandleException
        /// </summary>
        /// <param name="e"></param>
        private void HandleException(Exception e)
        {
        }
    }
}
