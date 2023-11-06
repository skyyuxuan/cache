using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xuan.Cache.Model.Storage;

namespace Xuan.Cache.Storage
{
    ///<seealso cref="IEntityCacheFactory"/>
    public class RedisEntityCacheFactory : IEntityCacheFactory
    {
        private readonly IRedisProviderFactory _redisFactory;
        private readonly ICacheSerializer _serializer;
        private readonly ICacheServiceConfiguration _configuration;
        public RedisEntityCacheFactory(IRedisProviderFactory redisFactory, ICacheSerializer serializer, ICacheServiceConfiguration configuration)
        {
            _redisFactory = redisFactory;
            _serializer = serializer;
            _configuration = configuration;
        }

        ///<seealso cref="IEntityCacheFactory.CreateEntityCache{TKey, TValue}(EntityCacheOption)"/>
        public IEntityCache<TKey, TValue> CreateEntityCache<TKey, TValue>(EntityCacheOption option) where TValue : class
        {
            var redisCache = _redisFactory.CreateProvider(_configuration.InstanceName);
            return new StackExchangeRedisEntityCache<TKey, TValue>(redisCache, _serializer, _configuration, option.EntityName);
        }
    }
}
