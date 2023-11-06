using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;
        public RedisEntityCacheFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        ///<seealso cref="IEntityCacheFactory.CreateEntityCache{TKey, TValue}(EntityCacheOptions)"/>
        public IEntityCache<TKey, TValue> CreateEntityCache<TKey, TValue>(EntityCacheOptions option) where TValue : class
        {
            return (IEntityCache<TKey, TValue>)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(StackExchangeRedisEntityCache<TKey, TValue>), option);
        }
    }
}
